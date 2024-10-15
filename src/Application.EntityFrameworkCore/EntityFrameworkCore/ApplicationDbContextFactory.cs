using Microsoft.EntityFrameworkCore;

namespace Application.EntityFrameworkCore;

public class ApplicationDbContextFactory :
    ApplicationDbContextFactoryBase<ApplicationDbContext>
{
    protected override ApplicationDbContext CreateDbContext(
        DbContextOptions<ApplicationDbContext> dbContextOptions)
    {
        return new ApplicationDbContext(dbContextOptions);
    }
}
