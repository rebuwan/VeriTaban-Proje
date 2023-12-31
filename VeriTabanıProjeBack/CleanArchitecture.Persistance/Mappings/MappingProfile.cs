using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, User>();
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<UpdateCourseCommand, Course>();
        CreateMap<CreateStaffCommand, Staff>();
        CreateMap<CreateDepartmentCommand, Department>();
        CreateMap<CreateStudendCommand,Student>();
    }
}
