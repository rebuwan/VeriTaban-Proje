using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.CreateMainRoleAndRoleRL;
public sealed class CreateMainRoleAndRoleRLCommandHandler : ICommandHandler<CreateMainRoleAndRoleRLCommand, MessageResponse>
{
    private readonly IMainRoleAndRoleRelasionshipService _service;

    public CreateMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelasionshipService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateMainRoleAndRoleRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship checkMainRoleAndRoleIsRelated = await _service.GetByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);

        if (checkMainRoleAndRoleIsRelated != null)
            throw new Exception("Bu Rol - Ana Rol İlişkisi Daha Önce Kurulmuştur !");

        MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(
            request.RoleId,
            request.MainRoleId);

        await _service.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);

        return new("Rol - Ana Rol İlişkisi Başarıyla Kuruldu !");
    }
}
