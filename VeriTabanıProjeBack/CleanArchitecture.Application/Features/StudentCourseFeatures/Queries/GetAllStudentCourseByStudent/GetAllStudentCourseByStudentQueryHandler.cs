using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
public sealed class GetAllStudentCourseByStudentQueryHandler : IQueryHandler<GetAllStudentCourseByStudentQuery, PaginationResult<GetAllStudentCourseByStudentQueryResponse>>
{
    private readonly IStudentCourseRelService _service;

    public GetAllStudentCourseByStudentQueryHandler(IStudentCourseRelService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllStudentCourseByStudentQueryResponse>> Handle(GetAllStudentCourseByStudentQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<StudentCourseRelationship> studentCourseRelationships = await _service.GetAllByStudent(request, cancellationToken);
        if (studentCourseRelationships == null || studentCourseRelationships.Datas == null) { throw new Exception("Her Hangi Bir Ders Kayıdınız Yoktur"); }

        int count = _service.GetCountByStudent(request);

        PaginationResult<GetAllStudentCourseByStudentQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: studentCourseRelationships.Datas.Select(p => new GetAllStudentCourseByStudentQueryResponse(
                CourseName: p.StaffCourses.Course.CourseName,
                CourseCode: p.StaffCourses.Course.CourseCode,
                StaffName: p.StaffCourses.Staff.Name + " " + p.StaffCourses.Staff.LastName,
                IsApproved: p.IsApproved,
                Count: count
                )).ToList());

        return response;
    }
}
