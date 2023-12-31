using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.UpdateRole;
public sealed class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, MessageResponse>
{
    private readonly IRoleService _service;

    public UpdateRoleCommandHandler(IRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = await _service.GetById(request.Id) ?? throw new Exception("Rol Kaydı Bulunamadı !");

        if (role.Code != request.Code)
        {
            Role checkRole = await _service.GetByCode(request.Code);

            if (checkRole != null)
                throw new Exception("Böyle Bir Rol Zaten Var !");
        }

        role.Code = request.Code;
        role.Name = request.Name;

        await _service.UpdateAsync(role);

        return new("Rol Kaydı Başarıyla Güncellendi !");
    }
}
