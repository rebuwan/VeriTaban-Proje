namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
public sealed record GetAllStaffCoursesByStaffQueryResponse(
    string StaffCourseId,
    string CourseId,
    string StaffId,
    string CourseCode,
    string CourseName,
    int CourseCredit,
    int StudentCount,
    int TotalCount
    );

