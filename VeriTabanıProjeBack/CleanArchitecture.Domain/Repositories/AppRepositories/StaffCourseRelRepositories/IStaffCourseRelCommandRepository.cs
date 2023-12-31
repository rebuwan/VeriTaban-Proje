using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.StaffCourseRelRepositories;
public interface IStaffCourseRelCommandRepository : IAppCommandRepository<StaffCourseRelationship>
{
}
