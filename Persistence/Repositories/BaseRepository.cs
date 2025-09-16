using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<RepositoryResult<TEntity>> GetByIdAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null
                ? RepositoryResult<TEntity>.Success(entity)
                : RepositoryResult<TEntity>.Failure("Entity not found");
        }
        catch (Exception ex)
        {
            return RepositoryResult<TEntity>.Failure($"Error retrieving entity: {ex.Message}");
        }
    }

    public virtual async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return RepositoryResult<IEnumerable<TEntity>>.Success(entities);
        }
        catch (Exception ex)
        {
            return RepositoryResult<IEnumerable<TEntity>>.Failure(
                $"Error retrieving entities: {ex.Message}"
            );
        }
    }

    public virtual async Task<RepositoryResult<TEntity>> AddAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RepositoryResult<TEntity>.Success(entity);
        }
        catch (Exception ex)
        {
            return RepositoryResult<TEntity>.Failure($"Error adding entity: {ex.Message}");
        }
    }

    public virtual async Task<RepositoryResult<TEntity>> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return RepositoryResult<TEntity>.Success(entity);
        }
        catch (Exception ex)
        {
            return RepositoryResult<TEntity>.Failure($"Error updating entity: {ex.Message}");
        }
    }

    public virtual async Task<RepositoryResult<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return RepositoryResult<bool>.Failure("Entity not found");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return RepositoryResult<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return RepositoryResult<bool>.Failure($"Error deleting entity: {ex.Message}");
        }
    }
}
