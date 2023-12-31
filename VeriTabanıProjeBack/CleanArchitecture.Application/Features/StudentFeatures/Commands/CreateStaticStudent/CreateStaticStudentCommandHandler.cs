using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.StaticList;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStaticStudent;
public sealed class CreateStaticStudentCommandHandler : ICommandHandler<CreateStaticStudentCommand, MessageResponse>
{
    private readonly IStudentService _service;

    public CreateStaticStudentCommandHandler(IStudentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateStaticStudentCommand request, CancellationToken cancellationToken)
    {
        IList<Student> courses = await _service.GetAll();
        IList<Student> studentList = StudentList.GetStaticStudents();
        IList<Student> newList = new List<Student>();

        foreach (var item in studentList)
        {
            if (!courses.Contains(item))
            {
                newList.Add(item);
            }
        }

        await _service.CreateRange(newList, cancellationToken);

        return new(newList.Count + "  Adet Personel Eklendi");
    }
}
