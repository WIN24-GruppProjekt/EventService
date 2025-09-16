using Persistence.Models;

namespace Persistence.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    Task<RepositoryResult<TEntity>> GetByIdAsync(Guid id);
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
    Task<RepositoryResult<TEntity>> AddAsync(TEntity entity);
    Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity);
    Task<RepositoryResult<bool>> DeleteAsync(Guid id);
}
