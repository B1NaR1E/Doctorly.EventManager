using Doctorly.EventManager.Infrastructure.Data;

namespace Doctorly.EventManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFContext _context;
    private bool _disposed = false;

    public UnitOfWork(EFContext contect)
    {
        _context = contect;
    }

    public TRepository Repository<TRepository>()
    {
        return (TRepository)Activator.CreateInstance(typeof(TRepository), _context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
