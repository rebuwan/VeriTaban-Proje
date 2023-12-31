using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.CourseRepositories;
public interface ICourseQueryRepository : IAppQueryRepository<Course>
{
}
