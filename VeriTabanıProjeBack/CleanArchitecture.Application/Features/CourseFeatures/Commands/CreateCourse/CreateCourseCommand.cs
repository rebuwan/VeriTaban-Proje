using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
public sealed record CreateCourseCommand(
    string DepartmentId,
    string CourseCode,
    string CourseName,
    int Credit) : ICommand<MessageResponse>;

