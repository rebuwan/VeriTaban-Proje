using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Commands.UpdateMainRole;
public sealed class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, MessageResponse>
{
    private readonly IMainRoleService _service;

    public UpdateMainRoleCommandHandler(IMainRoleService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole mainRole = await _service.GetByIdAsync(request.Id) ?? throw new Exception("Ana Rol Bulunamadı !");

        if (mainRole.Title == request.Title)
            throw new Exception("Güncellemeye Çalıştığınız Ana Rol Adı Eski Adıyla Aynıdır !");

        if (mainRole.Title != request.Title)
        {
            MainRole checkMainRoleTitle = await _service.GetByTitleAndDepartmentId(request.Title, mainRole.DepartmentId, cancellationToken);

            if (checkMainRoleTitle != null)
                throw new Exception("Bu Ana Rol Adı Daha Önce Kullanılmış !");

        }

        mainRole.Title = request.Title;

        await _service.UpdateAsync(mainRole);

        return new("Ana Rol Başarıyla Güncellendi !");

    }
}
