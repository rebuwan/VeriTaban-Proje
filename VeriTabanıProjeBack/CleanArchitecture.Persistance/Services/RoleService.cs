using AutoMapper;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;

    public RoleService(RoleManager<Role> roleManager, IMapper mapper, AppDbContext appDbContext)
    {
        _roleManager = roleManager;
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(CreateRoleCommand request)
    {
        Role role =_mapper.Map<Role>(request);

        await _roleManager.CreateAsync(role);
    }

    public async Task AddRangeAsync(IEnumerable<Role> roles)
    {
        foreach (var role in roles)
        {
            await _roleManager.CreateAsync(role);
        }
    }

    public async Task DeleteAsync(Role role)
    {
        await _roleManager.DeleteAsync(role);
    }

    public async Task<PaginationResult<Role>> GetAllByFilterRoles(GetAllByFilterRolesQuery request)
    {
        var count = GetCountByFilter(request.Search);

        if (request.Search != null)
        {
            var queryGetAllSearch = await _roleManager.Roles
                .Where(p => p.Title.Contains(request.Search))
                .ToPagedListAsync(1, count);

            return queryGetAllSearch;
        }

        var query = await _roleManager.Roles
            .ToPagedListAsync(1, count);

        return query;
    }

    public async Task<IList<Role>> GetAllRolesAync()
    {
        IList<Role> roles = await _roleManager.Roles.ToListAsync();

        return roles;
    }

    public async Task<Role> GetByCode(string code)
    {
        Role role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Code == code);

        return role;
    }

    public async Task<Role> GetById(string id)
    {
        Role role = await _roleManager.FindByIdAsync(id);

        return role;
    }

    public async Task<IList<Role>> GetByTitleRoles(string title)
    {
        IList<Role> roles = await _roleManager.Roles.Where(x => x.Title.Contains(title)).ToListAsync();

        return roles;
    }

    public int GetCountByFilter(string search)
    {
        if (search == null)
            return _roleManager.Roles
                .Count();

        return _roleManager.Roles
            .Where(p => p.Title.Contains(search))
            .Count();
    }

    public bool RoleIsHave(string roleId, string mainRoleId)
    {
        MainRoleAndRoleRelationship userRoles = _appDbContext.Set<MainRoleAndRoleRelationship>()
                .Where(p => p.MainRoleId == mainRoleId)
                .Where(p => p.Role.Id == roleId)
                .Include(p => p.Role)
                .FirstOrDefault();

        return userRoles != null ? true : false;
    }

    public async Task UpdateAsync(Role role)
    {
        await _roleManager.UpdateAsync(role);
    }
}
