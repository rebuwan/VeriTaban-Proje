using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffCourseRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StaffCourseRelRepositories;
public sealed class StaffCourseRelQueryRepository : AppQueryRepository<StaffCourseRelationship>, IStaffCourseRelQueryRepository
{
    public StaffCourseRelQueryRepository(AppDbContext context) : base(context)
    {
    }
}
