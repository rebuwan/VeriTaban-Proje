namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
public sealed record GetAllStudentCourseByStudentQueryResponse(
    string CourseName,
    string CourseCode,
    string StaffName,
    bool IsApproved,
    int Count
    );

