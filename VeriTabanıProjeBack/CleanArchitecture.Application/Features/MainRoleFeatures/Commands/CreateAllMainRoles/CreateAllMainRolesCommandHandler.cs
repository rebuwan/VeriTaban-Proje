using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Roles;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateAllMainRoles;
public sealed class CreateAllMainRolesCommandHandler : ICommandHandler<CreateAllMainRolesCommand, MessageResponse>
{
    private readonly IMainRoleService _service;

    public CreateAllMainRolesCommandHandler(IMainRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateAllMainRolesCommand request, CancellationToken cancellationToken)
    {
        List<MainRole> mainRoles = RoleList.GetStaticMainRoles();
        List<MainRole> newMainRoles = new List<MainRole>();

        foreach (var mainRole in mainRoles)
        {
            MainRole checkMainRole = await _service.GetByTitleAndDepartmentId(mainRole.Title, mainRole.DepartmentId, cancellationToken);
            
            if (checkMainRole == null)
                newMainRoles.Add(mainRole);
        }

        await _service.CreateRangeAsync(newMainRoles, cancellationToken);

        return new("Tüm Ana Roller Başarıyla Oluşturuldu !");
    }
}
