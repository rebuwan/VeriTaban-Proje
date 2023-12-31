using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = await _roleService.GetByCode(request.Code);

        if (role != null)
            throw new Exception("Bı Rol Daha Önce Kayıt Edilmiş !");

        await _roleService.AddAsync(request);

        return new("Rol Kaydı Başarıyla Tamamlandı !");
    }
}
