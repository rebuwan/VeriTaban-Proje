using CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface ICourseService
{
    public Task CreateAsync(CreateCourseCommand request, CancellationToken cancellationToken);
    public Task CreateRange(IList<Course> courses, CancellationToken cancellationToken);
    public Task UpdateAsync(UpdateCourseCommand request, CancellationToken cancellationToken);
    public Task RemoveAsync(string id, CancellationToken cancellationToken);

    public Task<Course> GetById(string id);
    public Task<Course> GetByCourseCode(string courseCode, CancellationToken cancellationToken);
    public Task<Course> GetByCourseName(string courseName, CancellationToken cancellationToken);
    public Task<PaginationResult<Course>> GetAllByFilter(GetAllCourseByFilterQuery request, CancellationToken cancellationToken);
    public Task<IList<Course>> GetAll();
    public int GetCount(string DepartmentId, string search);
    Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken);
}
