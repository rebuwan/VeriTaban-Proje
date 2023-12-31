using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
public sealed record GetAllByFilterMainRoleAndUserRLQuery(
    int PageNumber,
    int PageSize,
    string Search,
    string UserId
    ) : IQuery<PaginationResult<GetAllByFilterMainRoleAndUserRLQueryResponse>>;
