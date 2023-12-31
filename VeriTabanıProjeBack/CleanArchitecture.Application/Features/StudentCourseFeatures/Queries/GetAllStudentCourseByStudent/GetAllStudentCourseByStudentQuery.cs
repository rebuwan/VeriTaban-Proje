using CleanArchitecture.Application.Messaging;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
public sealed record GetAllStudentCourseByStudentQuery(
    string StudentId,
    string Search,
    int PageSize,
    int PageNumber
    ): IQuery<PaginationResult<GetAllStudentCourseByStudentQueryResponse>>;
