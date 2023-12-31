using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.CourseRepositories;
using CleanArchitecture.Domain.Repositories.GenericRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.CourseRepositories;
public sealed class CourseCommandRepository : AppCommandRepository<Course>, ICourseCommandRepository
{
    public CourseCommandRepository(AppDbContext context) : base(context)
    {
    }
}
