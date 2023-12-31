using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
public sealed class MainRoleAndRoleRelCommandRepository : AppCommandRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelCommandRepository
{
    public MainRoleAndRoleRelCommandRepository(AppDbContext context) : base(context)
    {
    }
}
