using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.AuthFeatures.Queries.GetAllByFilterUserRoles;
public sealed record GetAllByFilterUserRolesQueryResponse(
    UserRoleDto UserRoles);
