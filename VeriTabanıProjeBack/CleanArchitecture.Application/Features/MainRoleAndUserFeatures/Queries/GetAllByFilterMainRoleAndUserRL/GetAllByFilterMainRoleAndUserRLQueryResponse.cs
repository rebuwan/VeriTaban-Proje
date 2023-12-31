using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
public sealed record GetAllByFilterMainRoleAndUserRLQueryResponse(
    string MainRoleId,
    string MainRoleTitle,
    string MainRoleDepartmentId,
    Department? MainRoleDepartment,
    bool IsActive);
