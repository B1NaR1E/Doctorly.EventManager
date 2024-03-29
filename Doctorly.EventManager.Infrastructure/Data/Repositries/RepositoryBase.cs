﻿using Doctorly.EventManager.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

public class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly EFContext _context;
    public RepositoryBase(EFContext context)
    {
        _dbSet = context.Set<TEntity>();
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdateOn = DateTime.UtcNow;

        _dbSet.Update(entity);
        return Task.FromResult<TEntity>(entity);
    }

    //TODO: Rethink this. Added it here as IUnitOfWork was giving issues. If I have time. Sort this out.
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
