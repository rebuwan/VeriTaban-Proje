using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Commands.CreateStudentCourse;
public sealed class CreateStudentCourseRelCommandHandler : ICommandHandler<CreateStudentCourseRelCommand, MessageResponse>
{
    private readonly IStudentCourseRelService _service;

    public CreateStudentCourseRelCommandHandler(IStudentCourseRelService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateStudentCourseRelCommand request, CancellationToken cancellationToken)
    {
        StudentCourseRelationship relation = await _service.GetByRel(request.StudentId, request.CourseId, cancellationToken);
        if (relation != null) { throw new Exception("Bu Derse Kayıtlısınız"); }

        bool checkCourse = await _service.GetByCourse(request.StudentId, request.CourseId);
        if (checkCourse) { throw new Exception("Bu Derse Kayıtlısınız"); }

        await _service.CreateAsync(request, cancellationToken);

        return new("Ders Kaydı Başarılı");
    }
}
