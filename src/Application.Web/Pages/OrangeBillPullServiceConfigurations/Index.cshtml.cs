using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.OrangeBillPullServiceConfigurations;
using Application.Shared;

namespace Application.Web.Pages.OrangeBillPullServiceConfigurations
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public int? ServiceTypeIdFilterMin { get; set; }

        public int? ServiceTypeIdFilterMax { get; set; }
        [SelectItems(nameof(IsServiceEnabledBoolFilterItems))]
        public string IsServiceEnabledFilter { get; set; }

        public List<SelectListItem> IsServiceEnabledBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        [SelectItems(nameof(IsWebServiceEnabledBoolFilterItems))]
        public string IsWebServiceEnabledFilter { get; set; }

        public List<SelectListItem> IsWebServiceEnabledBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public string? WebServiceUrlFilter { get; set; }
        public string? StoredProcedureNameFilter { get; set; }
        public string? BillerCodeFilter { get; set; }
        public string? ConnectionStringUserIdFilter { get; set; }
        public string? ConnectionStringPasswordFilter { get; set; }
        public string? ConnectionStringDataSourceFilter { get; set; }
        public string? LogLevelFilter { get; set; }
        public int? SeverityIdFilterMin { get; set; }

        public int? SeverityIdFilterMax { get; set; }
        public int? DailyLimitFilterMin { get; set; }

        public int? DailyLimitFilterMax { get; set; }
        public int? WeeklyLimitFilterMin { get; set; }

        public int? WeeklyLimitFilterMax { get; set; }
        public int? MonthlyLimitFilterMin { get; set; }

        public int? MonthlyLimitFilterMax { get; set; }
        public int? YearlyLimitFilterMin { get; set; }

        public int? YearlyLimitFilterMax { get; set; }
        public string? ErrorMessageFilter { get; set; }

        protected IOrangeBillPullServiceConfigurationsAppService _orangeBillPullServiceConfigurationsAppService;

        public IndexModelBase(IOrangeBillPullServiceConfigurationsAppService orangeBillPullServiceConfigurationsAppService)
        {
            _orangeBillPullServiceConfigurationsAppService = orangeBillPullServiceConfigurationsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}