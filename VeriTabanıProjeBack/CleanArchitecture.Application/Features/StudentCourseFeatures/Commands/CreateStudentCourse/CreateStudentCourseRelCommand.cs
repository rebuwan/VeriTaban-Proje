using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Commands.CreateStudentCourse;
public sealed record CreateStudentCourseRelCommand(
    string StudentId,// Duz Id
    string CourseId // StaffCourseId
    ) : ICommand<MessageResponse>;

