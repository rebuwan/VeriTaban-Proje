using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.ChangeActivity;
public sealed record ChangeActivityCourseCommand(
    string Id,
    bool State) : ICommand<MessageResponse>;

