using AutoMapper;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.UpdateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class StudentService : IStudentService
{
    private readonly IStudentCommandRepository _commandRepository;
    private readonly IStudentQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IMainRoleService _mainRoleService;
    private readonly IMainRoleAndUserRelationshipService _roleAndUserRelationshipService;

    private readonly UserManager<User> _userManager;
    private readonly IDepartmentService _departmentService;

    public StudentService(IStudentCommandRepository commandRepository, IStudentQueryRepository queryRepository, IAppUnitOfWork unitOfWork, IMapper mapper, IDepartmentService departmentService, UserManager<User> userManager, IMainRoleService mainRoleService, IMainRoleAndUserRelationshipService roleAndUserRelationshipService)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _departmentService = departmentService;
        _userManager = userManager;
        _mainRoleService = mainRoleService;
        _roleAndUserRelationshipService = roleAndUserRelationshipService;
    }

    public async Task CreateAsync(CreateStudendCommand request, CancellationToken cancellationToken)
    {
        string StudentId = GenerateStudentId(request.EnrollmentDate.Date.Year, request.DepartmentId);
        User newUser = await GenerateUser(request, StudentId);

        MainRole mainRole = await _mainRoleService.GetByTitleAsync("Öğrenci", cancellationToken);

        Student newStudent = _mapper.Map<Student>(request);
        newStudent.UserId = newUser.Id;
        newStudent.StudentNo = StudentId;
        string photoPath = "";
        if (request.Photo != null)
        {
            photoPath = await SaveFileAsync(request.Photo);
            if (string.IsNullOrEmpty(photoPath)) { throw new Exception("Dosya Kaydedilirken Bir Sorun Oluştu"); }
            photoPath = photoPath.Replace("/wwwroot", "");
        }
        newStudent.StudentPhoto = string.IsNullOrEmpty(photoPath) ? "/userPhotos/avatar.png" : photoPath;

        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
                    userId: newStudent.UserId,
                    mainRoleId: mainRole.Id);

        await _roleAndUserRelationshipService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

        await _commandRepository.AddAsync(newStudent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(string studendId, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(studendId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<Student> GetById(string id)
    {
        return _queryRepository.GetById(id);
    }

    private string GenerateStudentId(int enrolYear, string departmentId)
    {
        int departmentCode = _departmentService.GetById(departmentId).Result.DepatmentCode;

        string idStart = enrolYear % 100 + departmentCode.ToString("D3");

        int count = _queryRepository.GetAll().Where(p => p.StudentNo.StartsWith(idStart)).Count();

        return idStart + count.ToString("D4");
    }
    private static string GenerateStudentEmail(string name, string lastName, int enrollYear)
    {
        return name.ToLower() + "." + lastName.ToLower() + (enrollYear % 100).ToString() + "@ogr.testuni.edu.tr";
    }

    private async Task<User> GenerateUser(CreateStudendCommand request, string StaffId)
    {
        User newUser = new()
        {
            UserName = StaffId,
            Email = GenerateStudentEmail(request.Name, request.LastName, request.EnrollmentDate.Year),
            NameLastName = request.Name + " " + request.LastName,
            DepartmentId = request.DepartmentId,
        };

        IdentityResult result = await _userManager.CreateAsync(newUser);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        return newUser;
    }

    public async Task<IList<Student>> GetAll()
    {
        return await _queryRepository.GetAll().ToListAsync();
    }

    public async Task<PaginationResult<Student>> GetAllByFilter(GetAllStudendQuery request)
    {
        var queryGetAll = _queryRepository
            .GetAll()
            .Where(p => request.Search == null || (p.Name + " " + p.LastName).Contains(request.Search) || p.StudentNo.Contains(request.Search))
            .Include(p => p.User)
            .ThenInclude(p => p.Department)
            .Where(p => request.DepartmentId == p.User.DepartmentId)
            .OrderByDescending(p => p.StudentNo);
        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
        return resultGetAll;

    }

    public int GetCount(GetAllStudendQuery request)
    {
        return _queryRepository.GetAll()
            .Where(p => request.Search == null || (p.Name + " " + p.LastName).Contains(request.Search) || p.StudentNo.Contains(request.Search))
            .Include(p => p.User)
            .Where(p => request.DepartmentId == null || request.DepartmentId.Contains(p.User.DepartmentId))
            .Count();
    }

    public async Task UpdateAsync(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        Student entitiy = await GetById(request.Id);
        entitiy.Name = request.Name;
        entitiy.LastName = request.LastName;

        _commandRepository.Update(entitiy);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
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

    public async Task<Student> GetByStudentNo(string no, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.StudentNo == no, cancellationToken);
    }

    public async Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken)
    {
        Student entity = await _queryRepository.GetById(Id) ?? throw new Exception("Öğrenci Bulunamadı");
        entity.IsActive = state;
        _commandRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task CreateRange(IList<Student> newList, CancellationToken cancellationToken)
    {
        string yazlimId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b";
        string bilgisayarId = "428a89af-c687-4a25-9383-1e2d9a5c85e4";
        string endustriId = "019936e5-55df-478b-a3f4-04e1168a96ca";
        string selectedDepartment = "";
        int count = newList.Count;

        MainRole mainRole = await _mainRoleService.GetByTitleAsync("Öğrenci", cancellationToken);

        for (int i = 0; i < newList.Count; i++)
        {

            if (i < count / 3 + 2)
                selectedDepartment = yazlimId;
            else if (i < count / 2)
                selectedDepartment = bilgisayarId;
            else if (i < count)
                selectedDepartment = endustriId;
            string studentno = generatestudentno(newList[i].EnrollmentDate.Year, i);

            newList[i].StudentNo = studentno;
            User newUser = new()
            {
                UserName = newList[i].StudentNo,
                Email = GenerateStudentEmail(newList[i].Name, newList[i].LastName, newList[i].Birthdate.Year),
                NameLastName = newList[i].Name + " " + newList[i].LastName,
                DepartmentId = selectedDepartment
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, "Password12*");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            newList[i].StudentPhoto = "/userPhotos/avatar.png";
            newList[i].UserId = newUser.Id;

            MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
                    userId: newUser.Id,
                    mainRoleId: mainRole.Id);

            await _roleAndUserRelationshipService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);
        }

        await _commandRepository.AddRangeAsync(newList, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        static string generatestudentno(int year, int count)
        {
            string noStart = year % 100 + 202.ToString("D3");
            string studentno = noStart + (count + 1).ToString("D4");
            return studentno;
        }
    }
}