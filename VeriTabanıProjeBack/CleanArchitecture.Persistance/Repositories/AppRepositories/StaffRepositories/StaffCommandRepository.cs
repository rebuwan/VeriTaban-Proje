using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StaffRepositories;
public sealed class StaffCommandRepository : AppCommandRepository<Staff>, IStaffCommandRepository
{
    public StaffCommandRepository(AppDbContext context) : base(context)
    {
    }
}
