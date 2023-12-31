using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.CreateMainRoleAndUserRL;
public sealed class CreateMainRoleAndUserRLCommandHandler : ICommandHandler<CreateMainRoleAndUserRLCommand, MessageResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;

    public CreateMainRoleAndUserRLCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByUserIdAndMainRoleIdAsync(request.UserId, request.MainRoleId, cancellationToken);

        if (checkEntity != null)
            throw new Exception("Kullanıcı Bu Ana Role Zaten Sahip !");

        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            userId: request.UserId,
            mainRoleId: request.MainRoleId);

        await _service.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

        return new("Kullanıcı - Ana Rol İlikisi Başarıyla Oluşturuldu !");
    }
}
