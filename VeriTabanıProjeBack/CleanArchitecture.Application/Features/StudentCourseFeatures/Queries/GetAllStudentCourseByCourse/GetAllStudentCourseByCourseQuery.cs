using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
public sealed record GetAllStudentCourseByCourseQuery(
        string CourseId,
    string Search,
    int PageSize,
    int PageNumber
    ) : IQuery<PaginationResult<GetAllStudentCourseByCourseQueryResponse>>;

