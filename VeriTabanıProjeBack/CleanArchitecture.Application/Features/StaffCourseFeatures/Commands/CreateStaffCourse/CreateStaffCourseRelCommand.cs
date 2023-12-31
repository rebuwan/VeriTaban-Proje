using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Commands.CreateStaffCourse;
public sealed record CreateStaffCourseRelCommand(
    string CourseId,
    string StaffUserId) : ICommand<MessageResponse> ;

