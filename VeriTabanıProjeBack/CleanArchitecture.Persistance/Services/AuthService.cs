using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.LoginForAFirstTime;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;

    private readonly IStudentService _studentService;
    private readonly IStaffService _staffService;
    private readonly IRoleService _roleService;
    private readonly IMainRoleAndRoleRelasionshipService _mainRoleAndRoleRelationshipService;

    private readonly AppDbContext _context;
    public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider, IStudentService studentService, IStaffService staffService, AppDbContext context, IRoleService roleService, IMainRoleAndRoleRelasionshipService roleRelasionshipService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
        _studentService = studentService;
        _staffService = staffService;
        _context = context;
        _roleService = roleService;
        _mainRoleAndRoleRelationshipService = roleRelasionshipService;
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId) ?? throw new Exception("Kullanıcı bulunamadı!");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Refresh Token geçerli değil!");

        if (user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Refresh Tokenun süresi dolmuş!");

        if (user.Email.Contains("@ogr"))
            return await ResponseAsStudent(user, cancellationToken);

        else if (user.Email.Contains("@test"))
            return await ResponseAsStaff(user, cancellationToken);


        LoginCommandResponse emptyresponse = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                UserId: user.Id,
                StaffId_StudentId: null,
                UserCode: null,
                NameLastName: user.NameLastName,
                UserPhoto: null,
                Department: new DepartmentDto(user.DepartmentId, user.Department.DepartmentName)
            );

        return emptyresponse;
    }

    public async Task<User> GetByEmailOrUserNameAsync(string emailOrUserName, CancellationToken cancellationToken)
    {
        return await _userManager.Users
            .Where(p => p.Email == emailOrUserName || p.UserName == emailOrUserName)
            .Include(p => p.Department)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Kullanıcı bulunamadı!");
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User user = await GetByEmailOrUserNameAsync(request.UserNameOrEmail, cancellationToken) ?? throw new Exception("Kullanıcı bulunamadı!");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
            throw new Exception("Şifreyi yanlış girdiniz!");

        if (user.Email.Contains("@ogr"))
            return await ResponseAsStudent(user, cancellationToken);

        else if (user.Email.Contains("@test"))
            return await ResponseAsStaff(user, cancellationToken);


        LoginCommandResponse emptyresponse = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                UserId: user.Id,
                StaffId_StudentId: null,
                UserCode: null,
                NameLastName: user.NameLastName,
                UserPhoto: null,
                Department: new DepartmentDto(user.DepartmentId, user.Department.DepartmentName)
            );

        return emptyresponse;

    }


    public async Task LoginForAFirstTime(LoginForAFirstTimeCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.Users.Where(p => p.UserName == request.UserId).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Kullanıcı Bilgileri Hatalı");

        DateTime userBirthdate = new DateTime();
        if (user.Email.Contains("@ogr"))
            userBirthdate = _studentService.GetByStudentNo(user.UserName, cancellationToken).Result.Birthdate;

        else if (user.Email.Contains("@test"))
            userBirthdate = _staffService.GetByStaffNo(user.UserName, cancellationToken).Result.Birthdate;

        if (request.Birthdate != userBirthdate) throw new Exception("Kullanıcı Bilgileri Hatalı");

        IdentityResult result = await _userManager.AddPasswordAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        List<string> emails = new();
        emails.Add(request.Email);
        string body = "";

        //await _mailService.SendMailAsync(emails, "Mail Onayı", body);
    }
    private async Task<LoginCommandResponse> ResponseAsStudent(User user, CancellationToken cancellationToken)
    {
        Student student = await _studentService.GetByStudentNo(user.UserName, cancellationToken);

        LoginCommandResponse response = new(
            Token: await _jwtProvider.CreateTokenAsync(user),
            UserId: user.Id,
            StaffId_StudentId: student.Id,
            UserCode: student.StudentNo,
            NameLastName: user.NameLastName,
            UserPhoto: student.StudentPhoto,
            Department: new DepartmentDto(user.DepartmentId, user.Department.DepartmentName)
       );
        return response;
    }

    private async Task<LoginCommandResponse> ResponseAsStaff(User user, CancellationToken cancellationToken)
    {
        Staff staff = await _staffService.GetByStaffNo(user.UserName, cancellationToken);

        LoginCommandResponse response = new(
            Token: await _jwtProvider.CreateTokenAsync(user),
            UserId: user.Id,
            StaffId_StudentId: staff.Id,
            UserCode: staff.StaffNo,
            NameLastName: user.NameLastName,
            UserPhoto: staff.Photo,
            Department: new DepartmentDto(user.DepartmentId, user.Department.DepartmentName)
        );
        return response;
    }

    public bool IsHaveMainRoleInUser(string userId, string mainRoleId)
    {
        MainRoleAndUserRelationship mainRole = _context.Set<MainRoleAndUserRelationship>()
            .Where(p => p.UserId == userId)
            .Where(p => p.MainRoleId == mainRoleId)
            .FirstOrDefault();

        return mainRole != null ? true : false;
    }

    public Task<User> GetByIdAsyncUser(string id)
    {
        var user = _userManager.FindByIdAsync(id);

        return user;
    }

    public string GetUserMainRoleByUserId(string userId)
    {
        var mainRole = _context.Set<MainRoleAndUserRelationship>()
            .Where(x => x.UserId == userId)
            .Include(p => p.MainRole)
            .FirstOrDefault();

        var mainRoleTitle = mainRole == null ? "" : mainRole.MainRole.Title;

        return mainRole == null ? null : mainRole.MainRole.Title;
    }

    public async Task<UserRoleDto> GetUserRolesByUserNameOrEmail(string userId)
    {
        var mainRole = _context.Set<MainRoleAndUserRelationship>()
            .Where(x => x.UserId == userId)
            .Include(p => p.MainRole)
            .FirstOrDefault();

        List<MainRoleAndRoleRelationship>? userRoles = new();

        if (mainRole != null)
        {
            if (mainRole.MainRole.Title == "Developer" || mainRole.MainRole.Title == "Bölüm Başkanı")
            //Eğer kullanıcı "Yönetici" ana rolüne sahip ise var olan tüm roller otomatik olarak atanır. Çünkü "Yönetici" ana rolünün her şeye erişimi olmalıdır.
            {
                IList<Role> roles = await _roleService.GetAllRolesAync();

                for (int i = 0; i < roles.Count(); i++)
                {
                    MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated =
                        await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(roles[i].Id, mainRole.MainRoleId, default);

                    if (checkRoleAndMainRoleIsRelated == null)
                    {
                        MainRoleAndRoleRelationship mainRoleAndRoleRelationShip = new(
                            roles[i].Id,
                            mainRole.MainRoleId
                        );

                        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationShip, default);
                    }
                }
            }

            if (mainRole.MainRole.Title == "Öğrenci")
            {
                IList<Role> roles = await _roleService.GetByTitleRoles("Öğrenci - Ders İlişkisi");

                for (int i = 0; i < roles.Count(); i++)
                {
                    MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated =
                        await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(roles[i].Id, mainRole.MainRoleId, default);

                    if (checkRoleAndMainRoleIsRelated == null)
                    {
                        MainRoleAndRoleRelationship mainRoleAndRoleRelationShip = new(
                            roles[i].Id,
                            mainRole.MainRoleId
                        );

                        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationShip, default);

                        break;
                    }
                }
            }

            if (mainRole.MainRole.Title == "Öğretim Üyesi")
            {
                IList<Role> roles = await _roleService.GetByTitleRoles("Öğretmen - Ders İlişkisi");

                for (int i = 0; i < roles.Count(); i++)
                {
                    MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated =
                        await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(roles[i].Id, mainRole.MainRoleId, default);

                    if (checkRoleAndMainRoleIsRelated == null)
                    {
                        MainRoleAndRoleRelationship mainRoleAndRoleRelationShip = new(
                            roles[i].Id,
                            mainRole.MainRoleId
                        );

                        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationShip, default);

                        break;
                    }
                }
            }

            if (mainRole.MainRole.Title == "Danışman")
            {
                IList<Role> roles = await _roleService.GetByTitleRoles("Öğrenciler");

                for (int i = 0; i < roles.Count(); i++)
                {
                    MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated =
                        await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(roles[i].Id, mainRole.MainRoleId, default);

                    if (checkRoleAndMainRoleIsRelated == null)
                    {
                        MainRoleAndRoleRelationship mainRoleAndRoleRelationShip = new(
                            roles[i].Id,
                            mainRole.MainRoleId
                        );

                        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationShip, default);

                        break;
                    }
                }
            }

            userRoles = _context.Set<MainRoleAndRoleRelationship>().Where(p => p.MainRoleId == mainRole.MainRoleId).Include(p => p.Role).ToList();
        }

        else
        {
            userRoles = null;
        }

        UserRoleDto role = new UserRoleDto(mainRole != null ? mainRole.MainRole.Title : null, userRoles?.Select(p => p.Role).ToList());

        return role;
    }
}
