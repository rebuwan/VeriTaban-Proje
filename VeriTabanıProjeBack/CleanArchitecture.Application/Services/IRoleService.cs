using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;

public interface IRoleService
{
    Task AddAsync(CreateRoleCommand request);
    Task AddRangeAsync(IEnumerable<Role> roles);
    Task UpdateAsync(Role role);
    Task DeleteAsync(Role role);
    Task<IList<Role>> GetAllRolesAync();
    Task<Role> GetById(string id);
    Task<Role> GetByCode(string code);
    Task<PaginationResult<Role>> GetAllByFilterRoles(GetAllByFilterRolesQuery request);
    public int GetCountByFilter(string search);
    public bool RoleIsHave(string roleId, string mainRoleId);
    Task<IList<Role>> GetByTitleRoles(string title);
}
