using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
public sealed record GetAllStudendQuery(
    int PageSize,
    int PageNumber,
    string Search,
    string DepartmentId
    ) : IQuery<PaginationResult<GetAllStudendQueryResponse>>;

