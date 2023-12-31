using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.RemoveByIdMainRoleAndRole;
public sealed class RemoveByIdMainRoleAndRoleCommandHandler : ICommandHandler<RemoveByIdMainRoleAndRoleCommand, MessageResponse>
{
    private readonly IMainRoleAndRoleRelasionshipService _service;

    public RemoveByIdMainRoleAndRoleCommandHandler(IMainRoleAndRoleRelasionshipService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveByIdMainRoleAndRoleCommand request, CancellationToken cancellationToken)
    {
        _ = await _service.GetByIdAsync(request.Id) ?? throw new Exception("Ana Rol - Rol İlişkisi Bulunamadı !");

        await _service.RemoveByIdAsync(request.Id);

        return new("Ana Rol - Rol İlişkisi Başarıyla Kaldırıldı !");
    }
}
