using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.UpdateStaff;
public sealed class UpdateStaffCommandHandler : ICommandHandler<UpdateStaffCommand, MessageResponse>
{
    private readonly IStaffService _staffService;

    public UpdateStaffCommandHandler(IStaffService staffService)
    {
        _staffService = staffService;
    }

    public async Task<MessageResponse> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {

        await _staffService.UpdateAsync(request, cancellationToken);

        await _staffService.UpdateUserAsync(request, cancellationToken);

        return new("Personel Güncellendi");
    }


}

