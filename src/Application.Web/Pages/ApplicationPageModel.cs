using Application.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Application.Web.Pages;

public abstract class ApplicationPageModel : AbpPageModel
{
    protected ApplicationPageModel()
    {
        LocalizationResourceType = typeof(ApplicationResource);
    }
}
