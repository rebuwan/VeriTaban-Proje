using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
using CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndDepartmentId(string title, string departmentId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken);
    Task<MainRole> GetByIdAsync(string id);
    Task<MainRole> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task UpdateAsync(MainRole mainRole);
    Task RemoveByIdAsync(string id, CancellationToken cancellationToken);
    Task<PaginationResult<MainRole>> GetAllByFilterMainRoles(GetAllByFilterMainRoleQuery request);
    public int GetCountByFilter(string search);
    Task<PaginationResult<MainRole>> GetAllByFilterMainRoleAndUserRL(GetAllByFilterMainRoleAndUserRLQuery request);
}
