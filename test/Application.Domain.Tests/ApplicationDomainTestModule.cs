using Application.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Application;

[DependsOn(
    typeof(ApplicationEntityFrameworkCoreTestModule)
    )]
public class ApplicationDomainTestModule : AbpModule
{

}
