
using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;


public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>  where TEntity : class 
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

    public virtual async Task<RepositoryResults<IEnumerable<TEntity>>> GetAllAsync
    (
        bool orderByDescending = false,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, bool>>? where = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if (where != null)
        {
            query = query.Where(where);
        }
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        if (orderBy != null)
        {
            query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }
        var result = await query.ToListAsync();
        return new RepositoryResults<IEnumerable<TEntity>>
        {
            Success = true,
            StatusCode = 200,
            Result = result
        };
    }
    public virtual async Task<RepositoryResults<IEnumerable<TSelect>>> GetAllAsync<TSelect>
    (
        Expression<Func<TEntity, TSelect>> selector, bool orderByDescending = false,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, bool>>? where = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if (where != null)
        {
            query = query.Where(where);
        }
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        if (orderBy != null)
        {
            query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }
        var result = await query.Select(selector).ToListAsync();
        return new RepositoryResults<IEnumerable<TSelect>>
        {
            Success = true,
            StatusCode = 200,
            Result = result
        };
    }

    public virtual async Task<RepositoryResults<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        var result = await query.FirstOrDefaultAsync(where);
        if (result == null)
        {
            return new RepositoryResults<TEntity>
            {
                Success = false,
                StatusCode = 404,
                Error = "Entity not found"
            };
        }
        return new RepositoryResults<TEntity>
        {
            Success = true,
            StatusCode = 200,
            Result = result
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
