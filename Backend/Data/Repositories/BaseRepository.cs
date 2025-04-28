
using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) where TEntity : class
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<RepositoryResults<bool>> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 400,
                Error = "Entity cannot be null"
            };
        }
        try
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResults<bool>
            {
                Success = true,
                StatusCode = 201,
                Result = true
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }

    public virtual async Task<RepositoryResults<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities =await _dbSet.ToListAsync();
            return new RepositoryResults<IEnumerable<TEntity>>
            {
                Success = true,
                StatusCode = 200,
                Result = entities
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new RepositoryResults<IEnumerable<TEntity>>
            {
                Success = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }

    public virtual async Task<RepositoryResults<TEntity>> GetAsync(Expression<Func<TEntity, bool>> findBy)
    {
        
        var entity = await _dbSet.FirstOrDefaultAsync(findBy);
        return entity != null
            ? new RepositoryResults<TEntity>
            {
                Success = true,
                StatusCode = 200,
                Result = entity
            }
            : new RepositoryResults<TEntity>
            {
                Success = false,
                StatusCode = 404,
                Error = "Entity not found"
            };
    }
    
    public virtual async Task<RepositoryResults<bool>> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 400,
                Error = "Entity cannot be null"
            };
        }
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResults<bool>
            {
                Success = true,
                StatusCode = 200,
                Result = true
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }
    public virtual async Task<RepositoryResults<bool>> DeleteAsync(TEntity entity)
    {
        if (entity == null)
        {
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 400,
                Error = "Entity cannot be null"
            };
        }
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResults<bool>
            {
                Success = true,
                StatusCode = 200,
                Result = true
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new RepositoryResults<bool>
            {
                Success = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }
    public virtual async Task<RepositoryResults<bool>> ExistAsync(Expression<Func<TEntity, bool>> findBy)
    {
        
        var exist = await _dbSet.AnyAsync(findBy);
        return  new RepositoryResults<bool>
        {
            Success = true,
            StatusCode = 200,
            Result = exist
        };
    }
}
