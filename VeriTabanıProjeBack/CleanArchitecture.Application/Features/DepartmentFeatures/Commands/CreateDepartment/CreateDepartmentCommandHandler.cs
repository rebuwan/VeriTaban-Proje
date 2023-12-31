using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
public sealed class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, MessageResponse>
{
    private readonly IDepartmentService _service;

    public CreateDepartmentCommandHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department checkName = await _service.GetByName(request.DepartmentName,cancellationToken);
        if (checkName != null) throw new Exception("Bu Isme Sahip Bir Bölüm Zaten Var!");

        await _service.CreateAsync(request,cancellationToken);

        return new("Bölüm Başarıyla Oluşturuldu");
    }
}
