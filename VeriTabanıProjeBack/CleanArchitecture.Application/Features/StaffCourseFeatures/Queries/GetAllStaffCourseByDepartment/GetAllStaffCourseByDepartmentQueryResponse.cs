namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
public sealed record GetAllStaffCourseByDepartmentQueryResponse(
    string Id,
    string StaffId,
    string StaffName,
    string CourseId,
    string CourseCode,
    string CourseName,
    int Credit,
    int TotalCount
    );

