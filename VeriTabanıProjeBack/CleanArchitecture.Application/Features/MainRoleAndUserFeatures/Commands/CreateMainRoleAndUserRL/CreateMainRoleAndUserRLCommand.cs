using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.CreateMainRoleAndUserRL;
public sealed record CreateMainRoleAndUserRLCommand(
    string UserId,
    string MainRoleId
    ) : ICommand<MessageResponse>;
