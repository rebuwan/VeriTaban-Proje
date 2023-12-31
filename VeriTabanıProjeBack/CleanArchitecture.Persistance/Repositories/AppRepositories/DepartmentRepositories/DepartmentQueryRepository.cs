using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.DepartmentRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.DepartmentRepositories;
public sealed class DepartmentQueryRepository : AppQueryRepository<Department>, IDepartmentQueryRepository
{
    public DepartmentQueryRepository(AppDbContext context) : base(context)
    {
    }
}
