using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.StaticList;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateStaticDepartments;
public sealed class CreateStaticDepartmentsCommnadsHandler : ICommandHandler<CreateStaticDepartmentsCommand, MessageResponse>
{
    private readonly IDepartmentService _service;

    public CreateStaticDepartmentsCommnadsHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateStaticDepartmentsCommand request, CancellationToken cancellationToken)
    {
        IList<Department> departments = await _service.GetAll();
        IList<Department> departmetnsList = DepartmentList.GetStaticDepartments();
        IList<Department> newList = new List<Department>();

        foreach (var item in departmetnsList)
        {
            if (!departments.Contains(item))
            {
                newList.Add(item);
            }
        }

        await _service.CreateRange(newList, cancellationToken);

        return new(newList.Count + "  Adet Departman Eklendi");
    }
}
