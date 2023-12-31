using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.ChangeActivity;
public sealed record ChangeActivityStudentCommand(
    string Id,
    bool State) : ICommand<MessageResponse>;

