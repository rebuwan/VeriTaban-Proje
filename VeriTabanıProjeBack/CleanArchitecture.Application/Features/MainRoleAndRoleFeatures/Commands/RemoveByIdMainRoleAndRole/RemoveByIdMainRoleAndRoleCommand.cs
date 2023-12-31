using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.RemoveByIdMainRoleAndRole;
public sealed record RemoveByIdMainRoleAndRoleCommand(
    string Id
    ) : ICommand<MessageResponse>;
