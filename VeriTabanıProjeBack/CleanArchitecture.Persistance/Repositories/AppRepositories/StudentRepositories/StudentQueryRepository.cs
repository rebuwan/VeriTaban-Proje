using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StudentRepositories;
public sealed class StudentQueryRepository : AppQueryRepository<Student>, IStudentQueryRepository
{
    public StudentQueryRepository(AppDbContext context) : base(context)
    {
    }
}
