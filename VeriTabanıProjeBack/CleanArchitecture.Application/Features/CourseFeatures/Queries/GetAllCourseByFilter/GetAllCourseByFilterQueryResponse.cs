using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
public sealed record GetAllCourseByFilterQueryResponse(
    string Id,
    string Code,
    string Name,
    int Credit,
    bool IsActive,
    IList<StaffDto> Staffs,
    int TotalCount
    );

