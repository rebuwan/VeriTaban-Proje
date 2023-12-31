using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.StudentRepositories;
public interface IStudentQueryRepository : IAppQueryRepository<Student>
{
}
