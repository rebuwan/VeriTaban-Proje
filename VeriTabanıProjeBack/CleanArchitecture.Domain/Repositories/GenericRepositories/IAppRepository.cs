using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Repositories.GenericRepositories;
public  interface IAppRepository<T> where T : Entity
{

    DbSet<T> Entity { get; set; }
}
