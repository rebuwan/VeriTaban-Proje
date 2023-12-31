using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.LoginForAFirstTime;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);

    Task LoginForAFirstTime(LoginForAFirstTimeCommand request, CancellationToken cancellationToken);
    public bool IsHaveMainRoleInUser(string userId, string mainRoleId);

    Task<User> GetByIdAsyncUser(string id);
    public string GetUserMainRoleByUserId(string userId);
    Task<UserRoleDto> GetUserRolesByUserNameOrEmail(string userId);
    Task<User> GetByEmailOrUserNameAsync(string emailOrUserName, CancellationToken cancellationToken);

}
