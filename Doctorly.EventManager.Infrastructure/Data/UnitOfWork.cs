using Doctorly.EventManager.Domain.Base;
using Doctorly.EventManager.Infrastructure.Data.Repositries;

namespace Doctorly.EventManager.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFContext _context;

    public UnitOfWork(EFContext context)
    {
        _context = context;
    }
    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        return new RepositoryBase<TEntity>(_context);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
