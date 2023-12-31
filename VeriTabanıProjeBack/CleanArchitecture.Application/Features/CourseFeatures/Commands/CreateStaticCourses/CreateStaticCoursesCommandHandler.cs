using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.StaticList;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateStaticCourses;
public sealed class CreateStaticCoursesCommandHandler : ICommandHandler<CreateStaticCoursesCommand, MessageResponse>
{
    private readonly ICourseService _service;

    public CreateStaticCoursesCommandHandler(ICourseService courseService)
    {
        _service = courseService;
    }

    public async Task<MessageResponse> Handle(CreateStaticCoursesCommand request, CancellationToken cancellationToken)
    {
        IList<Course> courses = await _service.GetAll();
        IList<Course> courseList = CourseList.GetStaticCourses();
        IList<Course> newList = new List<Course>();

        foreach (var item in courseList)
        {
            if (!courses.Contains(item))
            {
                newList.Add(item);
            }
        }

        await _service.CreateRange(newList, cancellationToken);

        return new(newList.Count + "  Adet Ders Eklendi");
    }
}
