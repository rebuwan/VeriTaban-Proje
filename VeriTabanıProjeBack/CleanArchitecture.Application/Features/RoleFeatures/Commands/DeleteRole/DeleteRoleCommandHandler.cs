using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.DeleteRole;
public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, MessageResponse>
{
    private IRoleService _service;

    public DeleteRoleCommandHandler(IRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = await _service.GetById(request.Id) ?? throw new Exception("Rol Kaydı Bulunamadı !");

        await _service.DeleteAsync(role);

        return new("Role Kaydı Başarıyla Silindi !");
    }
}
