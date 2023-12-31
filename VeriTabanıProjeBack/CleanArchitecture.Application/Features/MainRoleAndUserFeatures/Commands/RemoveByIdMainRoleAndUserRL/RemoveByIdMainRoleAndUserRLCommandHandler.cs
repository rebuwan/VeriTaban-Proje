using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.RemoveByIdMainRoleAndUserRL;
public sealed class RemoveByIdMainRoleAndUserRLCommandHandler : ICommandHandler<RemoveByIdMainRoleAndUserRLCommand, MessageResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;

    public RemoveByIdMainRoleAndUserRLCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveByIdMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        _ = await _service.GetByIdAsync(request.Id, false) ?? throw new Exception("Kullanıcı Bu Ana Role Sahip Değil !");

        await _service.RemoveByIdAsync(request.Id);

        return new("Kullanıcı - Ana Rol İlişkisi Başarıyla Kaldırıldı !");
    }
}
