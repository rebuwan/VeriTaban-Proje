using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateAllMainRoles;
public sealed record CreateAllMainRolesCommand(
    List<MainRole> MainRoles
    ) : ICommand<MessageResponse>;

