using Application.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Application.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ApplicationEntityFrameworkCoreModule),
    typeof(ApplicationApplicationContractsModule)
)]
public class ApplicationDbMigratorModule : AbpModule
{
}
