namespace Doctorly.EventManager.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    TRepository Repository<TRepository>();
    Task<int> SaveChangesAsync();
}
