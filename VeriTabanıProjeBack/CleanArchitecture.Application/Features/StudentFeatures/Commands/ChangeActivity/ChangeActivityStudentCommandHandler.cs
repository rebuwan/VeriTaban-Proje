using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.ChangeActivity;
public sealed class ChangeActivityStudentCommandHandler : ICommandHandler<ChangeActivityStudentCommand, MessageResponse>
{
    private readonly IStudentService _service;

    public ChangeActivityStudentCommandHandler(IStudentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(ChangeActivityStudentCommand request, CancellationToken cancellationToken)
    {
        await _service.ChangeActivity(request.Id, request.State, cancellationToken);

        return new("Öğrenci Durumu : " + (request.State ? "Aktif" : "Pasif"));
    }
}
