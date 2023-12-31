using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Dtos;
public sealed record UserRoleDto
(
    string MainRoleTitle,
    IList<Role> Roles
);
