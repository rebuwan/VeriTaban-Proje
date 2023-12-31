using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.DepartmentRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.DepartmentRepositories;
public sealed class DepartmentCommandRepository : AppCommandRepository<Department>, IDepartmentCommandRepository
{
    public DepartmentCommandRepository(AppDbContext context) : base(context)
    {
    }
}
