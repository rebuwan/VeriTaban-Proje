using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.IsHaveRoleInMainRole;
public sealed record IsHaveRoleInMainRoleCommand(
    string RoleId,
    string MainRoleId) : ICommand<MessageResponse>;
