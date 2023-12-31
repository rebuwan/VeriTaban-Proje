using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
public sealed record GetAllStaffCoursesByStaffQuery(
    string StaffId,
    string Search,
    int PageNumber,
    int PageSize) : IQuery<PaginationResult<GetAllStaffCoursesByStaffQueryResponse>>;
