using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
public sealed record GetAllByFilterMainRoleQuery(
    int PageNumber,
    int PageSize, 
    string Search
    ) : IQuery<PaginationResult<GetAllByFilterMainRoleQueryResponse>>;
