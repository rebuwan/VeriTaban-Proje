using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.UpdateRole;
public sealed record UpdateRoleCommand(
    string Id,
    string Code,
    string Name
    ) : ICommand<MessageResponse>;
