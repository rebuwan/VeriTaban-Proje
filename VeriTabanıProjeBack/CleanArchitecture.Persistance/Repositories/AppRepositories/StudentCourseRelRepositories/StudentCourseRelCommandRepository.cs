using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentCourseRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StudentCourseRelRepositories;
public sealed class StudentCourseRelCommandRepository : AppCommandRepository<StudentCourseRelationship>, IStudentCourseRelCommandRepository
{
    public StudentCourseRelCommandRepository(AppDbContext context) : base(context)
    {
    }
}
