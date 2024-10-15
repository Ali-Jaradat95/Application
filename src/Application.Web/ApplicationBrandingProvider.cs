using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Application.Web;

[Dependency(ReplaceServices = true)]
public class ApplicationBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Application";
}
