using Doctorly.EventManager.Infrastructure.Data;

namespace Doctorly.EventManager.Api.Services;

public interface IBaseService
{
    IUnitOfWork UnitOfWork { get; }
}
