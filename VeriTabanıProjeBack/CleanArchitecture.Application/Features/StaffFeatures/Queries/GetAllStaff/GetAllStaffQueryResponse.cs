namespace CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
public sealed record GetAllStaffQueryResponse(
    string Id,
    string UserId,
    string StaffNo,
    string Name,
    string LastName,
    bool IsActive,
    string MainRoleTitle,

    string Photo,
    DateTime BirthDate,
    string DepartmentId,

    int TotalCount);

