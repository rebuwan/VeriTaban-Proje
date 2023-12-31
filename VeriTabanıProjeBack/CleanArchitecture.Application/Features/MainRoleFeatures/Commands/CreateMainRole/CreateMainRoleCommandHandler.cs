using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateMainRole;
public sealed class CreateMainRoleCommandHandler : ICommandHandler<CreateMainRoleCommand, MessageResponse>
{
    private readonly IMainRoleService _service;

    public CreateMainRoleCommandHandler(IMainRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole _ = await _service.GetByTitleAndDepartmentId(request.Title, request.DepartmentId, cancellationToken);

        if (_ != null)
            throw new Exception("Bu Rol Daha Önce Oluşturulmuş !");

        MainRole mainRole = new(
            title: request.Title,
            departmentId: request.DepartmentId
            );

        await _service.CreateAsync(mainRole, cancellationToken);

        return new("Ana Rol Başarıyla Oluşturuldu !");
    }
}
