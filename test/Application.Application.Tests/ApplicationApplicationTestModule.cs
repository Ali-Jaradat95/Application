using Volo.Abp.Modularity;

namespace Application;

[DependsOn(
    typeof(ApplicationApplicationModule),
    typeof(ApplicationDomainTestModule)
    )]
public class ApplicationApplicationTestModule : AbpModule
{

}
