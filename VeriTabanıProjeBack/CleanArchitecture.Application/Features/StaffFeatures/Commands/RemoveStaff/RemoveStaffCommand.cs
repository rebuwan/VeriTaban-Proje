using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.RemoveStaff;
public sealed record RemoveStaffCommand(
    string Id,
    string UserId) : ICommand<MessageResponse>;

