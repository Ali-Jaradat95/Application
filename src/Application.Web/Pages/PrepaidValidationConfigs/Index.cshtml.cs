using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.PrepaidValidationConfigs;
using Application.Shared;

namespace Application.Web.Pages.PrepaidValidationConfigs
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? ServiceTypeFilter { get; set; }
        public string? ChannelCodeFilter { get; set; }
        public string? BillingNameFilter { get; set; }
        public string? AliasBillingNameFilter { get; set; }
        [SelectItems(nameof(IsTestingBoolFilterItems))]
        public string IsTestingFilter { get; set; }

        public List<SelectListItem> IsTestingBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public string? EndpointUrlFilter { get; set; }

        protected IPrepaidValidationConfigsAppService _prepaidValidationConfigsAppService;

        public IndexModelBase(IPrepaidValidationConfigsAppService prepaidValidationConfigsAppService)
        {
            _prepaidValidationConfigsAppService = prepaidValidationConfigsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}