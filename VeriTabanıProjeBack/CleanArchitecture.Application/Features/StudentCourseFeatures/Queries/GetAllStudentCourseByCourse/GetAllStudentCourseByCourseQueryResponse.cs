using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
public sealed record GetAllStudentCourseByCourseQueryResponse(
    string CourseId,
    string CourseName,
    string CourseCode,
    string StaffId, //GUID
    string StaffName,
    string StudentId,// GUID
    string StudentNo,
    string StudentName,
    bool IsApproved,
    int Count
    );

