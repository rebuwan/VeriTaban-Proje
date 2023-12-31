using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.CourseRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.CourseRepositories;
public sealed class CourseQueryRepository : AppQueryRepository<Course>, ICourseQueryRepository
{
    public CourseQueryRepository(AppDbContext context) : base(context)
    {
    }
}
