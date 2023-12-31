using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.RemoveStaff;
public sealed class RemoveStaffCommandHandler : ICommandHandler<RemoveStaffCommand, MessageResponse>
{
    private readonly IStaffService _service;

    public RemoveStaffCommandHandler(IStaffService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveStaffCommand request, CancellationToken cancellationToken)
    {
        _ = await _service.GetById(request.Id) ?? throw new Exception("Personel Bulunamadı");

        await _service.RemoveAsync(request, cancellationToken);
        return new MessageResponse("Personel Başarıyla Silindi");
    }
}
