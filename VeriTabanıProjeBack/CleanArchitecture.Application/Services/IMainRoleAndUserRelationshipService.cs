using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;
public interface IMainRoleAndUserRelationshipService
{
    Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string id);
    Task<MainRoleAndUserRelationship> GetByUserIdAndMainRoleIdAsync(string userId, string mainRoleId, CancellationToken cancellationToken);

    Task<MainRoleAndUserRelationship> GetByIdAsync(string id, bool isTracking);

    Task<MainRoleAndUserRelationship> GetRolesByUserId(string userId);
}
