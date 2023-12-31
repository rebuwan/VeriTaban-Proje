using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Queries.GetAllDepartments;
public sealed record GetAllDepartmentsQueryResponse(
    IList<Department> Departments
    );



