using Application.Localization;
using Volo.Abp.Application.Services;

namespace Application;

/* Inherit your application services from this class.
 */
public abstract class ApplicationAppService : ApplicationService
{
    protected ApplicationAppService()
    {
        LocalizationResource = typeof(ApplicationResource);
    }
}
