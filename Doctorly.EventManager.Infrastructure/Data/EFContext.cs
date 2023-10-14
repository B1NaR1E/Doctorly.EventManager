using Microsoft.EntityFrameworkCore;

namespace Doctorly.EventManager.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }
}
