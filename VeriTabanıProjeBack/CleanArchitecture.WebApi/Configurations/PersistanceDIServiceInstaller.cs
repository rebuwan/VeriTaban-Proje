using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories.AppRepositories.CourseRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.DepartmentRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffCourseRelRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentCourseRelRepositories;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using CleanArchitecture.Persistance.Repositories.AppRepositories.CourseRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.DepartmentRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.StaffCourseRelRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.StaffRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.StudentCourseRelRepositories;
using CleanArchitecture.Persistance.Repositories.AppRepositories.StudentRepositories;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.Persistance.UnitOfWork;
using CleanArchitecture.WebApi.Middleware;
using CleanArcihtecture.Infrastructure.Services;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {

        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

        #region Repository 
        
        services.AddScoped<IStudentCommandRepository,StudentCommandRepository>();
        services.AddScoped<IStudentQueryRepository,StudentQueryRepository>();

        services.AddScoped<IDepartmentCommandRepository,DepartmentCommandRepository>();
        services.AddScoped<IDepartmentQueryRepository,DepartmentQueryRepository>();

        services.AddScoped<IStaffCommandRepository, StaffCommandRepository>();
        services.AddScoped<IStaffQueryRepository, StaffQueryRepository>();

        services.AddScoped<IStaffCourseRelCommandRepository, StaffCourseRelCommandRepository>();
        services.AddScoped<IStaffCourseRelQueryRepository, StaffCourseRelQueryRepository>();


        services.AddScoped<IStudentCourseRelCommandRepository, StudentCourseRelCommandRepository>();
        services.AddScoped<IStudentCourseRelQueryRepository,StudentCourseRelQueryRepository>();

        services.AddScoped<ICourseCommandRepository, CourseCommandRepository>();
        services.AddScoped<ICourseQueryRepository,CourseQueryRepository>();

        services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
        services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository> ();

        services.AddScoped<IMainRoleAndRoleRelCommandRepository, MainRoleAndRoleRelCommandRepository>();
        services.AddScoped<IMainRoleAndRoleRelQueryRepository, MainRoleAndRoleRelQueryRepository>();

        services.AddScoped<IMainRoleAndUserRelCommandRepository, MainRoleAndUserRelCommandRepository>();
        services.AddScoped<IMainRoleAndUserRelQueryRepository, MainRoleAndUserRelQueryRepository>();



        #endregion

        #region ServicesApp
    //    services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();

        services.AddScoped<IMailService, MailService>();

        services.AddScoped<IStudentService,StudentService>();
        services.AddScoped<ICourseService,CourseService>();
        services.AddScoped<IStaffService,StaffService>();
        services.AddScoped<IDepartmentService,DepartmentService>();
        services.AddScoped<IStaffCourseRelService,StaffCourseRelService>();
 
        services.AddScoped<IStudentCourseRelService, StudentCourseRelService>();

        services.AddScoped<IMainRoleService, MainRoleService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IMainRoleAndRoleRelasionshipService, MainRoleAndRoleRelasionshipService>();
        services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();

        #endregion

    }
}
