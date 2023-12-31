using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
public sealed record GetAllCourseByFilterQuery(
    int PageNumber,
    int PageSize,
    string Search,
    string DepartmentId
    ) : IQuery<PaginationResult<GetAllCourseByFilterQueryResponse>>;
