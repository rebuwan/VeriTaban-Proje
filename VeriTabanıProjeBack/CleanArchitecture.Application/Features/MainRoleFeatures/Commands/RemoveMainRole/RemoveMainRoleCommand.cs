using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.RemoveMainRole;
public sealed record RemoveMainRoleCommand(
    string Id
    ) : ICommand<MessageResponse>;
