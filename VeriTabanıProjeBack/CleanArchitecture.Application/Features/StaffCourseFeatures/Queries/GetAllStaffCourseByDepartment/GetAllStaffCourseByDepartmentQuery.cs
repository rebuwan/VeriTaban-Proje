using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
public sealed record GetAllStaffCourseByDepartmentQuery(
    string Search,
    string DepartmentId,
    int PageSize,
    int PageNumber) : IQuery<PaginationResult<GetAllStaffCourseByDepartmentQueryResponse>>;

