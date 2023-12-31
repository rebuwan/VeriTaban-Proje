using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstractions;

public interface IJwtProvider
{
    Task<TokenRefreshTokenDto> CreateTokenAsync(User user);
}
