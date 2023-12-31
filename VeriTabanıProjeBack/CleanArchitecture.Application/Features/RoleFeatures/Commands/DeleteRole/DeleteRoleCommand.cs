using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.DeleteRole;
public sealed record DeleteRoleCommand(
    string Id
    ) : ICommand<MessageResponse>;
