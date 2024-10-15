using Application.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Application.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ApplicationController : AbpControllerBase
{
    protected ApplicationController()
    {
        LocalizationResource = typeof(ApplicationResource);
    }
}
