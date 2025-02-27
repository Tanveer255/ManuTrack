using Microsoft.EntityFrameworkCore;

namespace ReferenceService.Data;

public class ReferenceServiceDbContext : DbContext
{
    public ReferenceServiceDbContext(DbContextOptions<ReferenceServiceDbContext> options)
        : base(options)
    {

    }
}
