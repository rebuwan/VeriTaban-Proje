using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StudentRepositories;
public sealed class StudentCommandRepository : AppCommandRepository<Student>, IStudentCommandRepository
{
    public StudentCommandRepository(AppDbContext context) : base(context)
    {
    }
}
