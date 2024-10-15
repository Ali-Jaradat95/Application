using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PrepaidCategoryLookups;

namespace Application.Web.Pages.PrepaidCategoryLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PrepaidCategoryLookupCreateViewModel PrepaidCategoryLookup { get; set; }

        protected IPrepaidCategoryLookupsAppService _prepaidCategoryLookupsAppService;

        public CreateModalModelBase(IPrepaidCategoryLookupsAppService prepaidCategoryLookupsAppService)
        {
            _prepaidCategoryLookupsAppService = prepaidCategoryLookupsAppService;

            PrepaidCategoryLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PrepaidCategoryLookup = new PrepaidCategoryLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _prepaidCategoryLookupsAppService.CreateAsync(ObjectMapper.Map<PrepaidCategoryLookupCreateViewModel, PrepaidCategoryLookupCreateDto>(PrepaidCategoryLookup));
            return NoContent();
        }
    }

    public class PrepaidCategoryLookupCreateViewModel : PrepaidCategoryLookupCreateDto
    {
    }
}