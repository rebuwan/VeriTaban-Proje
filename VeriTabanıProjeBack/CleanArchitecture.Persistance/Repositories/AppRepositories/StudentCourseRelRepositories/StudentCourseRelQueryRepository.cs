using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentCourseRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StudentCourseRelRepositories;
public sealed class StudentCourseRelQueryRepository : AppQueryRepository<StudentCourseRelationship>, IStudentCourseRelQueryRepository
{
    public StudentCourseRelQueryRepository(AppDbContext context) : base(context)
    {
    }
}
