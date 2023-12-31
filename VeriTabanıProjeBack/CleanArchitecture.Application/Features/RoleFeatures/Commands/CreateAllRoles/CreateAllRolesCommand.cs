using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateAllRoles;
public sealed record CreateAllRolesCommand() : ICommand<MessageResponse>;
