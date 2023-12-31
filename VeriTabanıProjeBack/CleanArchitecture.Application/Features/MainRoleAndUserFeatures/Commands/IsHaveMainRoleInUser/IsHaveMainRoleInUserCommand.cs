using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.IsHaveMainRoleInUser;
public sealed record IsHaveMainRoleInUserCommand(
    string UserId,
    string MainRoleId
    ) : ICommand<MessageResponse>;
