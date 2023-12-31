using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
public sealed class GetAllByFilterMainRoleAndUserRLQueryHandler : IQueryHandler<GetAllByFilterMainRoleAndUserRLQuery, PaginationResult<GetAllByFilterMainRoleAndUserRLQueryResponse>>
{
    private readonly IMainRoleService _mainRoleService;
    private readonly IAuthService _authService;

    public GetAllByFilterMainRoleAndUserRLQueryHandler(IMainRoleService mainRoleService, IAuthService authService)
    {
        _mainRoleService = mainRoleService;
        _authService = authService;
    }

    public async Task<PaginationResult<GetAllByFilterMainRoleAndUserRLQueryResponse>> Handle(GetAllByFilterMainRoleAndUserRLQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<MainRole> result = await _mainRoleService.GetAllByFilterMainRoleAndUserRL(request);

        if (result == null || result.Datas == null)
            throw new Exception("Veri Bulunamadı !");

        int count = _mainRoleService.GetCountByFilter(request.Search);

        PaginationResult<GetAllByFilterMainRoleAndUserRLQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: count,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterMainRoleAndUserRLQueryResponse(
                MainRoleId: s.Id,
                MainRoleTitle: s.Title,
                MainRoleDepartmentId: s.DepartmentId,
                MainRoleDepartment: s.Department,
                IsActive: _authService.IsHaveMainRoleInUser(request.UserId, s.Id)
                )).ToList());

        return newResult;
    }
}
