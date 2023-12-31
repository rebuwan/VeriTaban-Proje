using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using CleanArchitecture.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class MainRoleAndRoleRelasionshipService : IMainRoleAndRoleRelasionshipService
{
    private IMainRoleAndRoleRelCommandRepository _mainRoleAndRoleRepositoryCommand; 
    private IMainRoleAndRoleRelQueryRepository _mainRoleAndRoleRepositoryQuery;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndRoleRelasionshipService(IMainRoleAndRoleRelCommandRepository mainRoleAndRoleRepositoryCommand, IMainRoleAndRoleRelQueryRepository mainRoleAndRoleRepositoryQuery, IAppUnitOfWork unitOfWork)
    {
        _mainRoleAndRoleRepositoryCommand = mainRoleAndRoleRepositoryCommand;
        _mainRoleAndRoleRepositoryQuery = mainRoleAndRoleRepositoryQuery;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationShip, CancellationToken cancellationToken)
    {
        await _mainRoleAndRoleRepositoryCommand.AddAsync(mainRoleAndRoleRelationShip, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRoleAndRoleRelationship> GetAll()
    {
        return _mainRoleAndRoleRepositoryQuery.GetAll();
    }

    public async Task<MainRoleAndRoleRelationship> GetByIdAsync(string id)
    {
        return await _mainRoleAndRoleRepositoryQuery.GetById(id);
    }

    public async Task<IList<MainRoleAndRoleRelationship>> GetByMainRoleIdForGetRolesAsync(string id)
    {
        return await _mainRoleAndRoleRepositoryQuery
            .GetWhere(x => x.MainRoleId == id)
            .Include("Role")
            .ToListAsync();
    }

    public async Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken)
    {
        return await _mainRoleAndRoleRepositoryQuery
            .GetFirstByExpression(x => x.RoleId == roleId && x.MainRoleId == mainRoleId, cancellationToken);
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _mainRoleAndRoleRepositoryCommand.RemoveById(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationShip)
    {
        _mainRoleAndRoleRepositoryCommand.Update(mainRoleAndRoleRelationShip);

        await _unitOfWork.SaveChangesAsync();
    }
}
