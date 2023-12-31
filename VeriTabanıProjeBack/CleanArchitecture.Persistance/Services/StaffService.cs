using AutoMapper;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.RemoveStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.UpdateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class StaffService : IStaffService
{
    private readonly IStaffCommandRepository _commandRepository;
    private readonly IStaffQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IMainRoleService _mainRoleService;
    private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserRelationshipService;

    private readonly UserManager<User> _userManager;
    public StaffService(IStaffCommandRepository commandRepository, IStaffQueryRepository queryRepository, IAppUnitOfWork unitOfWord, IMapper mapper, UserManager<User> userManager, IMainRoleService mainRoleService, IMainRoleAndUserRelationshipService mainRoleAndUserRelationshipService)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWord;
        _mapper = mapper;
        _userManager = userManager;
        _mainRoleService = mainRoleService;
        _mainRoleAndUserRelationshipService = mainRoleAndUserRelationshipService;
    }

    public async Task CreateAsync(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        string StaffId = GenerateStaffId();
        User newUser = await GenerateUser(request, StaffId);

        MainRole mainRole = await _mainRoleService.GetByTitleAsync("Öğretim Üyesi", cancellationToken);

        Staff newStaff = _mapper.Map<Staff>(request);
        newStaff.UserId = newUser.Id;
        newStaff.StaffNo = StaffId;
        string photoPath = "";
        if (request.Photo != null)
        {
            photoPath = await SaveFileAsync(request.Photo);
            if (string.IsNullOrEmpty(photoPath)) { throw new Exception("Dosya Kaydedilirken Bir Sorun Oluştu"); }
            photoPath = photoPath.Replace("/wwwroot", "");
        }
        newStaff.Photo = string.IsNullOrEmpty(photoPath) ? "/userPhotos/avatar.png" : photoPath;

        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            userId: newUser.Id,
            mainRoleId: mainRole.Id);

        await _mainRoleAndUserRelationshipService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

        await _commandRepository.AddAsync(newStaff, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<Staff> GetById(string id)
    {
        return _queryRepository.GetById(id);
    }

    public Task<Staff> GetByStaffCode(string staffcode, CancellationToken cancellationToken)
    {
        return _queryRepository.GetFirstByExpression(p => p.StaffNo == staffcode, cancellationToken);
    }

    public async Task RemoveAsync(RemoveStaffCommand request, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(request.Id);

        User user = _userManager.Users.FirstOrDefault(u => u.Id == request.UserId) ?? throw new Exception("Kullanıcı Bulunamadı");
        MainRoleAndUserRelationship rel = await _mainRoleAndUserRelationshipService.GetRolesByUserId(user.Id);
        await _mainRoleAndUserRelationshipService.RemoveByIdAsync(rel.Id);
        await _userManager.DeleteAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private string GenerateStaffId()
    {
        int count = _queryRepository.GetAll().Where(p => p.StaffNo.StartsWith((DateTime.Now.Year % 100).ToString())).Count() + 1;
        string staffId = (DateTime.Now.Year % 100).ToString() + count.ToString("D4");

        return staffId;
    }

    private string GenerateStaffEmail(string name, string lastName, int birthYear)
    {
        return name.ToLower() + "." + lastName.ToLower() + (birthYear % 100).ToString() + "@testuni.edu.tr";
    }

    private async Task<User> GenerateUser(CreateStaffCommand request, string StaffId)
    {
        User newUser = new()
        {
            UserName = StaffId,
            Email = GenerateStaffEmail(request.Name, request.LastName, request.Birthdate.Year),
            NameLastName = request.Name + " " + request.LastName,
            DepartmentId = request.DepartmentId
        };

        IdentityResult result = await _userManager.CreateAsync(newUser);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        return newUser;
    }

    public async Task<PaginationResult<Staff>> GetAllBySearch(GetAllStaffQuery request)
    {
        var queryGetAll = _queryRepository
             .GetAll()
             .Where(p => request.Search == null || (p.Name + " " + p.LastName).Contains(request.Search) || p.StaffNo.Contains(request.Search))
             .Include(p => p.User)
             .OrderBy(p => p.Name);
        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
        return resultGetAll;
    }

    public int GetCount(GetAllStaffQuery request)
    {
        return _queryRepository
             .GetAll()
             .Where(p => request.Search == null || (p.Name + " " + p.LastName).Contains(request.Search) || p.StaffNo.Contains(request.Search))
             .Count();
    }

    private async Task<string> SaveFileAsync(IFormFile myFile)
    {

        if (myFile != null)
        {
            if (myFile.Length > 3 * 1048576) throw new Exception("Dosya 3MB'tan Büyük Olamaz.");
            var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/userPhotos/", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await myFile.CopyToAsync(stream);
            }

            return path.Replace(Directory.GetCurrentDirectory(), "");

        }
        return "";
    }

    public async Task<Staff> GetByStaffNo(string no, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.StaffNo == no, cancellationToken);
    }

    public async Task UpdateAsync(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        Staff staff = await GetById(request.Id);
        staff.Name = request.Name;
        staff.LastName = request.LastName;
        staff.Birthdate = request.Birthdate;

        string photoPath = "";
        if (request.Photo != null)
        {
            photoPath = await SaveFileAsync(request.Photo);
            if (string.IsNullOrEmpty(photoPath)) { throw new Exception("Dosya Kaydedilirken Bir Sorun Oluştu"); }
            photoPath = photoPath.Replace("/wwwroot", "");
        }
        staff.Photo = string.IsNullOrEmpty(photoPath) ? staff.Photo : photoPath;

        _commandRepository.Update(staff);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateUserAsync(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        User user = _userManager.Users.FirstOrDefault(u => u.Id == request.UserId) ?? throw new Exception("Kullancı Bulunamadı");
        user.NameLastName = request.Name + " " + request.LastName;
        user.DepartmentId = request.DepartmentId;

        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken)
    {
        Staff entity = await _queryRepository.GetById(Id) ?? throw new Exception("Kullanıcı Bulunamadı");
        entity.IsActive = state;
        _commandRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRange(IList<Staff> newList, CancellationToken cancellationToken)
    {


        MainRole mainRole = await _mainRoleService.GetByTitleAsync("Öğretim Üyesi", cancellationToken);

        string selectedDepartment = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b";
        for (int i = 0; i < newList.Count; i++)
        {


            User newUser = new()
            {
                UserName = newList[i].StaffNo,
                Email = GenerateStaffEmail(newList[i].Name, newList[i].LastName, newList[i].Birthdate.Year),
                NameLastName = newList[i].Name + " " + newList[i].LastName,
                DepartmentId = selectedDepartment
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, "Password12*");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            newList[i].Photo = "/userPhotos/avatar.png";
            newList[i].UserId = newUser.Id;

            MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            userId: newUser.Id,
            mainRoleId: mainRole.Id);

            await _mainRoleAndUserRelationshipService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);
        }

        Staff newStaff = _mapper.Map<Staff>(newList[0]);
        newStaff.Name = "Admin";
        newStaff.LastName = "Administrator";
        newStaff.StaffNo = "00000";
        newStaff.Birthdate = new DateTime();
        newStaff.Photo = "/userPhotos/638387069695190731.png";

        User admin = new()
        {
            UserName = newStaff.StaffNo,
            Email = GenerateStaffEmail(newStaff.Name, newStaff.LastName, newStaff.Birthdate.Year),
            NameLastName = newStaff.Name + " " + newStaff.LastName,
            DepartmentId = selectedDepartment
        };

        newStaff.UserId = admin.Id;

        IdentityResult resultAdmin = await _userManager.CreateAsync(admin, "Admin12*");
        if (!resultAdmin.Succeeded)
        {
            throw new Exception(resultAdmin.Errors.First().Description);
        }

        MainRole adminRole = await _mainRoleService.GetByTitleAsync("Developer", cancellationToken);

        MainRoleAndUserRelationship mainRoleAndUserRelationshipAdmin = new(
            userId: admin.Id,
            mainRoleId: adminRole.Id);

        await _mainRoleAndUserRelationshipService.CreateAsync(mainRoleAndUserRelationshipAdmin, cancellationToken);

        await _commandRepository.AddRangeAsync(newList, cancellationToken);
        await _commandRepository.AddAsync(newStaff, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Staff>> GetAll()
    {
        return await _queryRepository.GetAll().ToListAsync();
    }
}
