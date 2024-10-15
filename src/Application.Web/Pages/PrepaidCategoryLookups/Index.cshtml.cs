using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.PrepaidCategoryLookups;
using Application.Shared;

namespace Application.Web.Pages.PrepaidCategoryLookups
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? CodeFilter { get; set; }
        public string? NameFilter { get; set; }
        public string? DescriptionFilter { get; set; }

        protected IPrepaidCategoryLookupsAppService _prepaidCategoryLookupsAppService;

        public IndexModelBase(IPrepaidCategoryLookupsAppService prepaidCategoryLookupsAppService)
        {
            _prepaidCategoryLookupsAppService = prepaidCategoryLookupsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}