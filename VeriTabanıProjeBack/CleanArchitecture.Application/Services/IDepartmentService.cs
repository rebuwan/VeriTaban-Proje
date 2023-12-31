using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;
public interface IDepartmentService
{
    Task CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken);
    Task CreateRange(IList<Department> newList, CancellationToken cancellationToken);
    Task<Department> GetById(string id);
    Task<Department> GetByName(string name, CancellationToken cancellationToken);

    Task<IList<Department>> GetAll();
    Task RemoveById(string id, CancellationToken cancellationToken);
}
