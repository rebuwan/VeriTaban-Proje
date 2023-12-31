using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
public sealed class MainRoleAndRoleRelQueryRepository : AppQueryRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelQueryRepository
{
    public MainRoleAndRoleRelQueryRepository(AppDbContext context) : base(context)
    {
    }
}
