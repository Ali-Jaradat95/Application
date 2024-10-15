using Microsoft.EntityFrameworkCore;

namespace Application.EntityFrameworkCore;

public class ApplicationTenantDbContextFactory :
    ApplicationDbContextFactoryBase<ApplicationTenantDbContext>
{
    protected override ApplicationTenantDbContext CreateDbContext(
        DbContextOptions<ApplicationTenantDbContext> dbContextOptions)
    {
        return new ApplicationTenantDbContext(dbContextOptions);
    }
}
