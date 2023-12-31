using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
public sealed class GetAllStaffCourseByDepartmentQueryHandler : IQueryHandler<GetAllStaffCourseByDepartmentQuery, PaginationResult<GetAllStaffCourseByDepartmentQueryResponse>>
{
    private readonly IStaffCourseRelService _service;

    public GetAllStaffCourseByDepartmentQueryHandler(IStaffCourseRelService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllStaffCourseByDepartmentQueryResponse>> Handle(GetAllStaffCourseByDepartmentQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<StaffCourseRelationship> staffCourseRel = await _service.GetAllByDepartment(request,cancellationToken);

        int count = _service.GetCount(request.DepartmentId, request.Search);

        PaginationResult<GetAllStaffCourseByDepartmentQueryResponse> response = new(
            pageSize: request.PageSize,
            pageNumber: request.PageNumber,
            totalCount: count,
            datas: staffCourseRel.Datas.Select(p=> new GetAllStaffCourseByDepartmentQueryResponse(
                Id: p.Id,
                StaffId: p.StaffId,
                StaffName: p.Staff.Name + " " + p.Staff.LastName, 
                CourseId: p.CourseId,
                CourseCode: p.Course.CourseCode,
                CourseName: p.Course.CourseName,
                Credit: p.Course.Credit,
                TotalCount: count
                )).ToList());
        return response;
    }
}
