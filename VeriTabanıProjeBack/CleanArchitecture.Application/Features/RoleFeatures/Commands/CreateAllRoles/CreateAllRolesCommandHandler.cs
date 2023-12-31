using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Roles;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateAllRoles;
public sealed class CreateAllRolesCommandHandler : ICommandHandler<CreateAllRolesCommand, MessageResponse>
{
    private readonly IRoleService _service;

    public CreateAllRolesCommandHandler(IRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateAllRolesCommand request, CancellationToken cancellationToken)
    {
        IList<Role> originalRoleList = RoleList.GetStaticRoles();

        IList<Role> currentRoleList = new List<Role>();

        foreach (var role in originalRoleList)
        {
            Role checkRole = await _service.GetByCode(role.Code);
            
            if (checkRole == null)
                currentRoleList.Add(role);
        }

        await _service.AddRangeAsync(currentRoleList);

        return new("Tüm Roller Başarıyla Oluşturuldu !");
    }
}
