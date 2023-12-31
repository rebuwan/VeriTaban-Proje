using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.DepartmentRepositories;
public  interface IDepartmentCommandRepository : IAppCommandRepository<Department>
{
}
