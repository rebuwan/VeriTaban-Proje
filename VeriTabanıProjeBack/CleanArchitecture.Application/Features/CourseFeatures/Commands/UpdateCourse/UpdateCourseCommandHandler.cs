using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
public sealed class UpdateCourseCommandHandler : ICommandHandler<UpdateCourseCommand, MessageResponse>
{
    private ICourseService _service;

    public UpdateCourseCommandHandler(ICourseService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        _ = await _service.GetById(request.Id) ?? throw new Exception("Ders Bulunamadı.");

        await _service.UpdateAsync(request, cancellationToken);

        return new("Ders Başarıyla Güncellendi");
    }
}
