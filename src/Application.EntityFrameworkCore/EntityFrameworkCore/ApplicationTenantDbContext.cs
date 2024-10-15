using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Application.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class ApplicationTenantDbContext : ApplicationDbContextBase<ApplicationTenantDbContext>
{
    public ApplicationTenantDbContext(DbContextOptions<ApplicationTenantDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetMultiTenancySide(MultiTenancySides.Tenant);

        base.OnModelCreating(builder);
    }
}
