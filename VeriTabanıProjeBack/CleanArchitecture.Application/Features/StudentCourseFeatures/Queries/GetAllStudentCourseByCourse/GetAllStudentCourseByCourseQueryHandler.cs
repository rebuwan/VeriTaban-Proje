using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
public sealed class GetAllStudentCourseByCourseQueryHandler : IQueryHandler<GetAllStudentCourseByCourseQuery, PaginationResult<GetAllStudentCourseByCourseQueryResponse>>
{
    private readonly IStudentCourseRelService _service;

    public GetAllStudentCourseByCourseQueryHandler(IStudentCourseRelService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllStudentCourseByCourseQueryResponse>> Handle(GetAllStudentCourseByCourseQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<StudentCourseRelationship> studentCourseRelationships = await _service.GetAllByCourse(request, cancellationToken);
        if (studentCourseRelationships == null) { throw new Exception("Her Hangi Bir Ders Kayıdınız Yoktur"); }

        int count = _service.GetCountByCourse(request.CourseId);

        PaginationResult<GetAllStudentCourseByCourseQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: studentCourseRelationships.Datas.Select(p => new GetAllStudentCourseByCourseQueryResponse(
                CourseId: p.StaffCourseId,
                CourseName: p.StaffCourses.Course.CourseName,
                CourseCode: p.StaffCourses.Course.CourseCode,
                StaffId: p.StaffCourses.Staff.Id,
                StaffName: p.StaffCourses.Staff.Name + " " + p.StaffCourses.Staff.LastName,
                StudentId: p.StudentId,
                StudentNo: p.Student.StudentNo,
                StudentName: p.Student.Name + " " + p.Student.LastName,
                IsApproved: p.IsApproved,
                Count: count
                )).ToList());

        return response;
    }
}
