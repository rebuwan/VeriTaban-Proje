using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateMainRole;
public sealed record CreateMainRoleCommand(
    string Title,
    string DepartmentId = null
    ): ICommand<MessageResponse>;
