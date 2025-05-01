using System;
using System.Linq.Expressions;
using Data.Models;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<RepositoryResults<bool>> AddAsync(TEntity entity);
    Task<RepositoryResults<IEnumerable<TEntity>>> GetAllAsync(
        bool orderByDescending = false,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, bool>>? where = null,
        params Expression<Func<TEntity, object>>[] includes);
    Task<RepositoryResults<IEnumerable<TSelect>>> GetAllAsync<TSelect>
    (
        Expression<Func<TEntity, TSelect>> selector, bool orderByDescending = false,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, bool>>? where = null,
        params Expression<Func<TEntity, object>>[] includes);
    Task<RepositoryResults<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where,
        params Expression<Func<TEntity, object>>[] includes);
    Task<RepositoryResults<bool>> UpdateAsync(TEntity entity);
    Task<RepositoryResults<bool>> DeleteAsync(TEntity entity);
    Task<RepositoryResults<bool>> ExistAsync(Expression<Func<TEntity, bool>> findBy);
}