using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.LoginForAFirstTime;
public sealed class LoginForAFirstTimeCommandHandler : ICommandHandler<LoginForAFirstTimeCommand, MessageResponse>
{
    private readonly IAuthService _service;

    public LoginForAFirstTimeCommandHandler(IAuthService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(LoginForAFirstTimeCommand request, CancellationToken cancellationToken)
    {
            await _service.LoginForAFirstTime(request, cancellationToken);

        return new("Kullanıcı Kaydı Başarılı. Sisteme Giriş Yapabilirsiniz.");
    }
}
