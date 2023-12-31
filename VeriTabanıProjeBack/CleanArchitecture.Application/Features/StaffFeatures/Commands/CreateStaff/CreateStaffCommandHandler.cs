using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
public sealed class CreateStaffCommandHandler : ICommandHandler<CreateStaffCommand, MessageResponse>
{
    private readonly IStaffService _staffService;

    public CreateStaffCommandHandler(IStaffService staffService)
    {
        _staffService = staffService;
    }

    public async Task<MessageResponse> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        await _staffService.CreateAsync(request, cancellationToken);

        return new("Personel Başarıyla Oluşturuldu");
    }
}
