using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
public sealed class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, MessageResponse>
{
    private readonly ICourseService _courseService;

    public CreateCourseCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<MessageResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        Course checkCode = await _courseService.GetByCourseCode(request.CourseCode, cancellationToken);
        if(checkCode != null && checkCode.DepartmentId ==request.DepartmentId) { throw new Exception("Bu Koda Sahip Bir Ders Zaten Var."); }

        Course checkName = await _courseService.GetByCourseName(request.CourseName, cancellationToken);
        if (checkName != null && checkCode.DepartmentId == request.DepartmentId) { throw new Exception("Bu İsme Sahip Bir Ders Zaten Var."); }

        await _courseService.CreateAsync(request, cancellationToken);

        return new("Ders Başarıyla Oluşturuldu");
    }

    
}
