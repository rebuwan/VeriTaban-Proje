namespace CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
public sealed record GetAllByFilterMainRoleQueryResponse(
    string Id,
    string Title,
    string DepartmentId
    );