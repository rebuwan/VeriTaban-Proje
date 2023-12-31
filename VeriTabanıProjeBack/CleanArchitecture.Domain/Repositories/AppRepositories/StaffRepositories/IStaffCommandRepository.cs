using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.StaffRepositories;
public interface IStaffCommandRepository : IAppCommandRepository<Staff>
{
}
