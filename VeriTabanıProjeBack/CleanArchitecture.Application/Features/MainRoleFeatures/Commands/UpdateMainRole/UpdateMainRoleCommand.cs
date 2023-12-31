using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.UpdateMainRole;
public sealed record UpdateMainRoleCommand(
    string Id,
    string Title
    ) : ICommand<MessageResponse>;
