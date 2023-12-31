using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
public sealed class GetAllStaffQueryHandler : IQueryHandler<GetAllStaffQuery, PaginationResult<GetAllStaffQueryResponse>>
{
    private readonly IStaffService _service;
    private readonly IAuthService _authService;

    public GetAllStaffQueryHandler(IStaffService service, IAuthService authService)
    {
        _service = service;
        _authService = authService;
    }


    public async Task<PaginationResult<GetAllStaffQueryResponse>> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Staff> students = await _service.GetAllBySearch(request);
        if (students == null || students.Datas == null)
            throw new Exception("Veri Bulunamadı");

        int count = _service.GetCount(request);

        PaginationResult<GetAllStaffQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: students.Datas.Select(p => new GetAllStaffQueryResponse(
                Id: p.Id,
                UserId: p.UserId,
                StaffNo: p.StaffNo,
                Name: p.Name,
                LastName: p.LastName,
                IsActive: p.IsActive,
                MainRoleTitle: _authService.GetUserMainRoleByUserId(p.UserId),
                Photo: p.Photo,
                DepartmentId: p.User.DepartmentId,
                BirthDate: p.Birthdate,
                TotalCount: count
            )).ToList());

        return response;
    }
}
