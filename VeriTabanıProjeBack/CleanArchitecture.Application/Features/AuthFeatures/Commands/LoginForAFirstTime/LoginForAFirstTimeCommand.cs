using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.LoginForAFirstTime;
public sealed record LoginForAFirstTimeCommand(
    string UserId,
    DateTime Birthdate,
    string Password) : ICommand<MessageResponse>;

