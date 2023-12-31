using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.ChangeActivity;
public sealed record ChangeActivityStaffCommand(
    string Id,
    bool State) : ICommand<MessageResponse>;

