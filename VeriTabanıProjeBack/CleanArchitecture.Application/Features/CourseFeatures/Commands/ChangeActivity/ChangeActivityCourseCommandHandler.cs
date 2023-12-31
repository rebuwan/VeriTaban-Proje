using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.ChangeActivity;
public sealed class ChangeActivityCourseCommandHandler : ICommandHandler<ChangeActivityCourseCommand, MessageResponse>
{
    private readonly ICourseService _service;

    public ChangeActivityCourseCommandHandler(ICourseService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(ChangeActivityCourseCommand request, CancellationToken cancellationToken)
    {
        await _service.ChangeActivity(request.Id, request.State, cancellationToken);

        return new("Kurs Durumu : " + (request.State ? "Aktif" : "Pasif"));
    }
}
