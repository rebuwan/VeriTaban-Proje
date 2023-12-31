using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffCourseRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StaffCourseRelRepositories;
public sealed class StaffCourseRelCommandRepository : AppCommandRepository<StaffCourseRelationship>, IStaffCourseRelCommandRepository
{
    public StaffCourseRelCommandRepository(AppDbContext context) : base(context)
    {
    }
}
