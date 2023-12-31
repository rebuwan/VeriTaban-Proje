using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Repositories.GenericRepositories;
public interface IAppCommandRepository<T> : IAppRepository<T> where T : Entity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
void Update(T entity);
void UpdateRange(IEnumerable<T> entities);
Task RemoveById(string id);
void Remove(T entity);
void RemoveRange(IEnumerable<T> entities);

}
