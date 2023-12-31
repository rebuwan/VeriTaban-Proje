using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.RemoveCourse;
public sealed class RemoveCourseCommandHandler : ICommandHandler<RemoveCourseCommand, MessageResponse>
{
    private readonly ICourseService _service;

    public RemoveCourseCommandHandler(ICourseService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        Course course = await _service.GetById(request.Id) ?? throw new Exception("Ders Bulunamadı");

        await _service.RemoveAsync(request.Id,cancellationToken);
        return new(course.CourseName + " Isimli Ders Başarıyla Kaldırıldı");
             
    }
}

