using CleanArchitecture.Application.Features.StudentCourseFeatures.Commands.CreateStudentCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface IStudentCourseRelService
{
    Task CreateAsync(CreateStudentCourseRelCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string Id, CancellationToken cancellationToken);
    Task<StudentCourseRelationship> GetByRel(string StudentId, string CourseId, CancellationToken cancellationToken);
    Task<PaginationResult<StudentCourseRelationship>> GetAllByCourse(GetAllStudentCourseByCourseQuery request, CancellationToken cancellationToken);
    Task<PaginationResult<StudentCourseRelationship>> GetAllByStudent(GetAllStudentCourseByStudentQuery request, CancellationToken cancellationToken);

    int GetCountByStudent(GetAllStudentCourseByStudentQuery request);
    int GetCountByCourse(string CourseId);
    Task<bool> GetByCourse(string studentId, string courseId);
}
