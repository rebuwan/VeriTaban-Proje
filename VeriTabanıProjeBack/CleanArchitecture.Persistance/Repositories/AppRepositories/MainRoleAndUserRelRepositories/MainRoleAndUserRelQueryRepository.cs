using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
public sealed class MainRoleAndUserRelQueryRepository : AppQueryRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelQueryRepository
{
    public MainRoleAndUserRelQueryRepository(AppDbContext context) : base(context)
    {
    }
}
