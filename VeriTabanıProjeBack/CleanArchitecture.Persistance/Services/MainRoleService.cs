using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
using CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Persistance.Services;
public sealed class MainRoleService : IMainRoleService
{
    private readonly IMainRoleCommandRepository _commandRepository;
    private readonly IMainRoleQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleService(IMainRoleCommandRepository commandRepository, IMainRoleQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken)
    {
        await _commandRepository.AddRangeAsync(mainRoles, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<MainRole>> GetAllByFilterMainRoleAndUserRL(GetAllByFilterMainRoleAndUserRLQuery request)
    {
        var count = GetCountByFilter(request.Search);

        if (request.Search != null)
        {
            var queryGetAllSearch = _queryRepository
                .GetAll()
                .Where(p => p.Title.Contains(request.Search));

            var resultGetAllSearch = await queryGetAllSearch.ToPagedListAsync(1, count);

            return resultGetAllSearch;
        }

        var query = _queryRepository
            .GetAll();

        var result = await query.ToPagedListAsync(1, count);

        return result;
    }

    public async Task<PaginationResult<MainRole>> GetAllByFilterMainRoles(GetAllByFilterMainRoleQuery request)
    {
        if (request.Search != null)
        {
            var queryGetAllSearch = _queryRepository
                .GetAll()
                .Where(p => p.Title.Contains(request.Search));

            var resultGetAllSearch = await queryGetAllSearch.ToPagedListAsync(request.PageNumber, request.PageSize);

            return resultGetAllSearch;
        }

        var query = _queryRepository
            .GetAll();

        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);

        return result;
    }

    public async Task<MainRole> GetByIdAsync(string id)
    {
        return await _queryRepository.GetById(id);
    }

    public async Task<MainRole> GetByTitleAndDepartmentId(string title, string departmentId, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(x => x.Title == title && x.DepartmentId == departmentId, cancellationToken, false);
    }

    public async Task<MainRole> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(x => x.Title == title, cancellationToken, false);
    }

    public int GetCountByFilter(string search)
    {
        if (search == null)
            return _queryRepository
                .GetAll()
                .Count();

        return _queryRepository
            .GetAll()
            .Where(p => p.Title.Contains(search))
            .Count();
    }

    public async Task RemoveByIdAsync(string id, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(MainRole mainRole)
    {
        _commandRepository.Update(mainRole);
        await _unitOfWork.SaveChangesAsync();
    }
}
