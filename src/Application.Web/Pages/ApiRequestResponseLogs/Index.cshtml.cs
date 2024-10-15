using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.ApiRequestResponseLogs;
using Application.Shared;

namespace Application.Web.Pages.ApiRequestResponseLogs
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? RequestUrlFilter { get; set; }
        public string? RequestMethodFilter { get; set; }
        public string? RequestHeadersFilter { get; set; }
        public string? RequestBodyFilter { get; set; }
        public string? ResponseBodyFilter { get; set; }
        public int? ResponseStatusCodeFilterMin { get; set; }

        public int? ResponseStatusCodeFilterMax { get; set; }
        public string? ResponseHeadersFilter { get; set; }
        public int? DurationMsFilterMin { get; set; }

        public int? DurationMsFilterMax { get; set; }
        public DateTime? CreatedAtFilterMin { get; set; }

        public DateTime? CreatedAtFilterMax { get; set; }
        public string? CorrelationIdFilter { get; set; }
        public string? IpAddressFilter { get; set; }
        public string? UserIdFilter { get; set; }
        public string? ErrorDetailsFilter { get; set; }
        [SelectItems(nameof(IsSuccessfulBoolFilterItems))]
        public string IsSuccessfulFilter { get; set; }

        public List<SelectListItem> IsSuccessfulBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public string? SourceSystemFilter { get; set; }

        protected IApiRequestResponseLogsAppService _apiRequestResponseLogsAppService;

        public IndexModelBase(IApiRequestResponseLogsAppService apiRequestResponseLogsAppService)
        {
            _apiRequestResponseLogsAppService = apiRequestResponseLogsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}