using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
public sealed record GetAllByFilterRolesQuery(
    int PageNumber,
    int PageSize,
    string Search,
    string MainRoleId
    ) : IQuery<PaginationResult<GetAllByFilterRolesQueryResponse>>;
