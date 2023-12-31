using CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.UpdateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface IStudentService
{
    Task CreateAsync(CreateStudendCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateStudentCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string studendId, CancellationToken cancellationToken);

    Task<Student> GetById(string id);
    Task<IList<Student>> GetAll();
    Task<PaginationResult<Student>> GetAllByFilter(GetAllStudendQuery request);
    Task<Student> GetByStudentNo(string no, CancellationToken cancellationToken);
    int GetCount(GetAllStudendQuery request);
    Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken);
    Task CreateRange(IList<Student> newList, CancellationToken cancellationToken);
}
