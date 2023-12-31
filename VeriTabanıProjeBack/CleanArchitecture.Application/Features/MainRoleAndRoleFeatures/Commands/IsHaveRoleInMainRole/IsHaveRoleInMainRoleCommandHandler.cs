using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.IsHaveRoleInMainRole;
public sealed class IsHaveRoleInMainRoleCommandHandler : ICommandHandler<IsHaveRoleInMainRoleCommand, MessageResponse>
{
    private readonly IMainRoleAndRoleRelasionshipService _mainRoleAndRoleRelasionshipService;
    private readonly IMainRoleService _mainRoleService;
    private readonly IRoleService _roleService;

    public IsHaveRoleInMainRoleCommandHandler(IMainRoleAndRoleRelasionshipService mainRoleAndRoleRelasionshipService, IMainRoleService mainRoleService, IRoleService roleService)
    {
        _mainRoleAndRoleRelasionshipService = mainRoleAndRoleRelasionshipService;
        _mainRoleService = mainRoleService;
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(IsHaveRoleInMainRoleCommand request, CancellationToken cancellationToken)
    {
        var mainRoleIsHaveRole = _roleService.RoleIsHave(request.RoleId, request.MainRoleId);

        Role role = await _roleService.GetById(request.RoleId);

        MainRole mainRole = await _mainRoleService.GetByIdAsync(request.MainRoleId);

        if (!mainRoleIsHaveRole)
        {
            MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(
                request.RoleId,
                request.MainRoleId);

            await _mainRoleAndRoleRelasionshipService.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);

            MessageResponse response = new($"{role.Name} Rolü {mainRole.Title} Ana Rolüne Başarıyla Eklendi !");

            return response;
        }
        
        else
        {
            MainRoleAndRoleRelationship checkRolaAndMainRoleIsRelated = await _mainRoleAndRoleRelasionshipService.GetByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);

            await _mainRoleAndRoleRelasionshipService.RemoveByIdAsync(checkRolaAndMainRoleIsRelated.Id);

            MessageResponse response = new($"{role.Name} Rolü {mainRole.Title} Ana Rolünden Başarıyla Kaldırıldı !");

            return response;
        }
    }
}
