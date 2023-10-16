using Doctorly.EventManager.Infrastructure.Data;

namespace Doctorly.EventManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFContext _context;

    public UnitOfWork(EFContext contect)
    {
        _context = contect;
    }

    public TRepository? Repository<TRepository>()
    {
        return (TRepository?)Activator.CreateInstance(typeof(TRepository), _context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
