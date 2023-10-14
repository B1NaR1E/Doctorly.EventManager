using Doctorly.EventManager.Domain.Base;
using System.Linq.Expressions;

namespace Doctorly.EventManager.Infrastructure.Data.Repositries;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
}
