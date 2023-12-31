using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
using CleanArchitecture.Domain.UnitOfWork;

namespace CleanArchitecture.Persistance.Services;
public sealed class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
{
    private readonly IMainRoleAndUserRelCommandRepository _commandRepository;
    private readonly IMainRoleAndUserRelQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndUserRelationshipService(IMainRoleAndUserRelCommandRepository commandRepository, IMainRoleAndUserRelQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndUserRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetByIdAsync(string id, bool isTracking)
    {
        return await _queryRepository.GetById(id, false);
    }

    public async Task<MainRoleAndUserRelationship> GetByUserIdAndMainRoleIdAsync(string userId, string mainRoleId, CancellationToken cancellationToken)
    {
        return await _queryRepository
            .GetFirstByExpression(x => x.UserId == userId && x.MainRoleId == mainRoleId, cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetRolesByUserId(string userId)
    {
        return await _queryRepository
            .GetFirstByExpression(x => x.UserId == userId, default);
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
