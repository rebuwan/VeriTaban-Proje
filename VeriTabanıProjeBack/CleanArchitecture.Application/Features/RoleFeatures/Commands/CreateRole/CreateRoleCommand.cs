using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Code,
    string Name): ICommand<MessageResponse>;
