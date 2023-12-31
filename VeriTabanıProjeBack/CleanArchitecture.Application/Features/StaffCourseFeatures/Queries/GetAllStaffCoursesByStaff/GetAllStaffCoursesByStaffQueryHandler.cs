using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
public sealed class GetAllStaffCoursesByStaffQueryHandler : IQueryHandler<GetAllStaffCoursesByStaffQuery, PaginationResult<GetAllStaffCoursesByStaffQueryResponse>>
{
    private readonly IStaffCourseRelService _service;
    private readonly IStudentCourseRelService _studentCourseRelService;

    public GetAllStaffCoursesByStaffQueryHandler(IStaffCourseRelService service, IStudentCourseRelService studentCourseRelService)
    {
        _service = service;
        _studentCourseRelService = studentCourseRelService;
    }

    public async Task<PaginationResult<GetAllStaffCoursesByStaffQueryResponse>> Handle(GetAllStaffCoursesByStaffQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<StaffCourseRelationship> result = await _service.GetAllByStaff(request, cancellationToken);
        int Count = _service.GetCountByStaff(request.StaffId, request.Search);

        PaginationResult<GetAllStaffCoursesByStaffQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: Count,
            datas: result.Datas.Select(p => new GetAllStaffCoursesByStaffQueryResponse(
                StaffCourseId: p.Id,
                CourseId: p.CourseId,
                StaffId: p.StaffId,
                CourseCode: p.Course.CourseCode,
                CourseName: p.Course.CourseName,
                CourseCredit: p.Course.Credit,
                StudentCount: _studentCourseRelService.GetCountByCourse(p.Id),
                TotalCount: Count
                )).ToList());

        return response;
    }
}
