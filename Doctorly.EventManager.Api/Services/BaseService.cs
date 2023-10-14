using Doctorly.EventManager.Infrastructure.Data;

namespace Doctorly.EventManager.Api.Services;

public abstract class BaseService
{
    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; set; }
}
