using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
public sealed record UpdateCourseCommand(
    string Id,
    string CourseCode,
    string CourseName,
    int Credit,
    string DepartmentId) : ICommand<MessageResponse>; 

