using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.MainRoleRepositories;
public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
{
    public MainRoleQueryRepository(AppDbContext context) : base(context)
    {
    }
}
