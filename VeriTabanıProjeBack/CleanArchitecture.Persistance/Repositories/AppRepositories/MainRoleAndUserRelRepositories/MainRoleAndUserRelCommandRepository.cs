using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
public sealed class MainRoleAndUserRelCommandRepository : AppCommandRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelCommandRepository
{
    public MainRoleAndUserRelCommandRepository(AppDbContext context) : base(context)
    {
    }
}
