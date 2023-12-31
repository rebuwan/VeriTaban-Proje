using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
public sealed record GetAllStaffQuery (
    int PageNumber,
    int PageSize,
    string Search): IQuery<PaginationResult<GetAllStaffQueryResponse>>;

