using Doctorly.EventManager.Domain.Base;
using Doctorly.EventManager.Infrastructure.Data.Repositries;

namespace Doctorly.EventManager.Infrastructure.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
}
