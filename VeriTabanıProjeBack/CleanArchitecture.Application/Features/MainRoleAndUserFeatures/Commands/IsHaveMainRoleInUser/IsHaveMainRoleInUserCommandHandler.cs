using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.IsHaveMainRoleInUser;
public sealed class IsHaveMainRoleInUserCommandHandler : ICommandHandler<IsHaveMainRoleInUserCommand, MessageResponse>
{
    private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserRelationshipService;
    private readonly IMainRoleService _mainRoleService;
    private readonly IAuthService _authService;

    public IsHaveMainRoleInUserCommandHandler(IMainRoleAndUserRelationshipService mainRoleAndUserRelationshipService, IMainRoleService mainRoleService, IAuthService authService)
    {
        _mainRoleAndUserRelationshipService = mainRoleAndUserRelationshipService;
        _mainRoleService = mainRoleService;
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(IsHaveMainRoleInUserCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship result = await _mainRoleAndUserRelationshipService.GetRolesByUserId(request.UserId);

        User user = await _authService.GetByIdAsyncUser(request.UserId);

        MainRole mainRole = await _mainRoleService.GetByIdAsync(request.MainRoleId);

        if (result != null)
        {
            var userIsHaveMainrole = _authService.IsHaveMainRoleInUser(request.UserId, request.MainRoleId);

            if (userIsHaveMainrole)
            {
                MainRoleAndUserRelationship query = await _mainRoleAndUserRelationshipService.GetByUserIdAndMainRoleIdAsync(request.UserId, request.MainRoleId, cancellationToken);

                await _mainRoleAndUserRelationshipService.RemoveByIdAsync(query.Id);

                MessageResponse responsee = new(
                    Message: $"{mainRole.Title} Ana Rolü {user.NameLastName} Kullanıcısından Başarıyla Kaldırıldı.");

                return responsee;
            }

            else
            {
                MainRoleAndUserRelationship query = await _mainRoleAndUserRelationshipService.GetByUserIdAndMainRoleIdAsync(request.UserId, result.MainRoleId, cancellationToken);

                await _mainRoleAndUserRelationshipService.RemoveByIdAsync(query.Id);
            }
        }

        MainRoleAndUserRelationship newMainRoleAndUserRelationship = new(
            userId: request.UserId,
            request.MainRoleId);

        await _mainRoleAndUserRelationshipService.CreateAsync(newMainRoleAndUserRelationship, cancellationToken);

        MessageResponse response = new(
                Message: $"{mainRole.Title} Ana Rolü {user.NameLastName} Kullanıcısına Başarıyla Atandı.");

        return response;
    }
}
