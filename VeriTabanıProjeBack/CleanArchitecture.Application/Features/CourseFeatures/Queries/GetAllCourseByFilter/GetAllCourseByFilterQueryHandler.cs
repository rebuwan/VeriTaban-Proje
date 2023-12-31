using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
public sealed class GetAllCourseByFilterQueryHandler : IQueryHandler<GetAllCourseByFilterQuery, PaginationResult<GetAllCourseByFilterQueryResponse>>
{
    private readonly ICourseService _service;

    public GetAllCourseByFilterQueryHandler(ICourseService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllCourseByFilterQueryResponse>> Handle(GetAllCourseByFilterQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Course> courses = await _service.GetAllByFilter(request, cancellationToken);

        int count = _service.GetCount(request.DepartmentId,request.Search);

        PaginationResult<GetAllCourseByFilterQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: courses.Datas.Select(p => new GetAllCourseByFilterQueryResponse(
                Id: p.Id,
                Code: p.CourseCode,
                Name: p.CourseName,
                Credit:p.Credit,
                IsActive: p.IsActive,
                Staffs: p.Staffs.Select(p => new StaffDto(p.Staff.StaffNo, p.Staff.Name)).ToList(),
                TotalCount: count
                )).ToList());

        return response;
    }
}
