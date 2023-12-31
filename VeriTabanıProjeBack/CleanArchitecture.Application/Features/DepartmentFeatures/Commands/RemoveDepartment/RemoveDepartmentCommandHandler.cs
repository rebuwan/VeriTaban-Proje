using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.RemoveDepartment;
public sealed class RemoveDepartmentCommandHandler : ICommandHandler<RemoveDepartmentCommand, MessageResponse>
{
    private readonly IDepartmentService _service;

    public RemoveDepartmentCommandHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoveById(request.Id, cancellationToken);

        return new("Bölüm Silindi");
    }
}
