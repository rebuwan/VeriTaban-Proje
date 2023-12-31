using CleanArchitecture.Application.Features.StaffCourseFeatures.Commands.CreateStaffCourse;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface IStaffCourseRelService
{
    public Task CreateAsync(CreateStaffCourseRelCommand request, CancellationToken cancellationToken);
    // public Task UpdateAsync(UpdateCourseCommand request, CancellationToken cancellationToken);
    public Task RemoveAsync(string id, CancellationToken cancellationToken);

    public Task<StaffCourseRelationship> GetById(string id);
    public Task<StaffCourseRelationship> GetByRelation(string CourseId, string StaffUserId, CancellationToken cancellationToken);
    public Task<PaginationResult<StaffCourseRelationship>> GetAllByDepartment(GetAllStaffCourseByDepartmentQuery request, CancellationToken cancellationToken);
    public int GetCount(string DepartmentId, string search);
    public Task<PaginationResult<StaffCourseRelationship>> GetAllByStaff(GetAllStaffCoursesByStaffQuery request, CancellationToken cancellationToken);
    int GetCountByStaff(string staffId, string search);
}
