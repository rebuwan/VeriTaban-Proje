using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.CreateMainRoleAndRoleRL;
public sealed record CreateMainRoleAndRoleRLCommand(
    string RoleId,
    string MainRoleId
    ) : ICommand<MessageResponse>;
