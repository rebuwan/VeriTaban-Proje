using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
public sealed class GetAllByFilterMainRoleQueryHandler : IQueryHandler<GetAllByFilterMainRoleQuery, PaginationResult<GetAllByFilterMainRoleQueryResponse>>
{
    private readonly IMainRoleService _mainRoleService;
    private readonly IAuthService _authService;

    public GetAllByFilterMainRoleQueryHandler(IMainRoleService mainRoleService, IAuthService authService)
    {
        _mainRoleService = mainRoleService;
        _authService = authService;
    }

    public async Task<PaginationResult<GetAllByFilterMainRoleQueryResponse>> Handle(GetAllByFilterMainRoleQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<MainRole> result = await _mainRoleService.GetAllByFilterMainRoles(request);

        if (result == null || result.Datas == null)
            throw new Exception("Veri Bulunamdı !");

        int count = _mainRoleService.GetCountByFilter(request.Search);

        PaginationResult<GetAllByFilterMainRoleQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterMainRoleQueryResponse(
                Id: s.Id,
                Title: s.Title,
                DepartmentId: s.DepartmentId
                )).ToList());

        return newResult;
    }
}
