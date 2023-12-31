using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.RemoveByIdMainRoleAndUserRL;
public sealed record RemoveByIdMainRoleAndUserRLCommand(
    string Id
    ) : ICommand<MessageResponse>;
