using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.ChangeActivity;
public sealed class ChangeActivityStaffCommandHandler : ICommandHandler<ChangeActivityStaffCommand, MessageResponse>
{
    private readonly IStaffService _service;

    public ChangeActivityStaffCommandHandler(IStaffService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(ChangeActivityStaffCommand request, CancellationToken cancellationToken)
    {
        await _service.ChangeActivity(request.Id, request.State, cancellationToken);

        return new("Personel Durumu : " + (request.State ? "Aktif" : "Pasif"));
    }
}
