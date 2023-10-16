namespace Doctorly.EventManager.Infrastructure;

public interface IUnitOfWork
{
    TRepository? Repository<TRepository>();
    Task<int> SaveChangesAsync();
}
