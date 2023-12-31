using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
public sealed class GetAllByFilterRolesQueryHandler : IQueryHandler<GetAllByFilterRolesQuery, PaginationResult<GetAllByFilterRolesQueryResponse>>
{
    private readonly IRoleService _service;

    public GetAllByFilterRolesQueryHandler(IRoleService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllByFilterRolesQueryResponse>> Handle(GetAllByFilterRolesQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Role> result = await _service.GetAllByFilterRoles(request);

        if (result == null || result.Datas == null)
             throw new Exception("Veri Bulunamadı !");

        int count = _service.GetCountByFilter(request.Search);

        PaginationResult<GetAllByFilterRolesQueryResponse> newResult = new(
            pageNumber: 1,
            pageSize: count,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterRolesQueryResponse(
                Id: s.Id,
                Name: s.Name,
                NormalizedName: s.NormalizedName,
                ConcurrencyStamp: s.ConcurrencyStamp,
                Code: s.Code,
                Title: s.Title,
                IsActive: _service.RoleIsHave(s.Id, request.MainRoleId)
                )).ToList());

        return newResult;
    }
}
