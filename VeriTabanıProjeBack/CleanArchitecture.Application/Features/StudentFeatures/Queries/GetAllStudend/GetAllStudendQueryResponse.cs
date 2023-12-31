namespace CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
public sealed record GetAllStudendQueryResponse(
       string Id,
       string StudentNo,
       string Name,
       string LastName,
       string PhotoUrl,
       string DepartmentName,
       string DepartmentId,
       DateTime EnrollDate,
       DateTime Birthdate,
       bool IsActive,
       int TotalCount
    );

