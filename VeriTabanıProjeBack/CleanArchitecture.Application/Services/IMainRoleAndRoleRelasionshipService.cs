using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;
public interface IMainRoleAndRoleRelasionshipService
{
    Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationShip, CancellationToken cancellationToken);
    Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationShip);
    Task RemoveByIdAsync(string id);
    Task<MainRoleAndRoleRelationship> GetByIdAsync(string id);
    Task<IList<MainRoleAndRoleRelationship>> GetByMainRoleIdForGetRolesAsync(string id);
    IQueryable<MainRoleAndRoleRelationship> GetAll();
    Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken);
}
