using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Queries.GetAllDepartments;
public sealed class GetAllDepartmentsQueryHandler : IQueryHandler<GetAllDepartmentsQuery, GetAllDepartmentsQueryResponse>
{
    private readonly IDepartmentService _service;

    public GetAllDepartmentsQueryHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        IList<Department> departments = await _service.GetAll();

        return new(departments);

    }
}
