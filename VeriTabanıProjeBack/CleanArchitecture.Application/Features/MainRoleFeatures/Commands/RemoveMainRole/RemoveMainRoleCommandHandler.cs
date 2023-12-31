using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.RemoveMainRole;
public sealed class RemoveMainRoleCommandHandler : ICommandHandler<RemoveMainRoleCommand, MessageResponse>
{
    private readonly IMainRoleService _service;

    public RemoveMainRoleCommandHandler(IMainRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveMainRoleCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoveByIdAsync(request.Id, cancellationToken);

        return new("Ana Rol Kaydı Başarıyla Silindi");
    }
}
