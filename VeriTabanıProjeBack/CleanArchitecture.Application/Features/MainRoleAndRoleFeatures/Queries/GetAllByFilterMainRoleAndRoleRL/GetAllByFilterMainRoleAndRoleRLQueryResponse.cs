using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Queries.GetAllByFilterMainRoleAndRoleRL;
public sealed record GetAllByFilterMainRoleAndRoleRLQueryResponse(
    List<MainRoleAndRoleRelationship> MainRoleAndRoleRelationships
    );
