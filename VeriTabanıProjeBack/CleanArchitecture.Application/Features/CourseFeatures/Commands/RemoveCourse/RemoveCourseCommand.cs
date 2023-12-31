using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.RemoveCourse;
public sealed record RemoveCourseCommand(
    string Id) : ICommand<MessageResponse>;

