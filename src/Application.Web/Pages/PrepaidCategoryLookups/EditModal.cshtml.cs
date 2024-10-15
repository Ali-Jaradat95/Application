using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PrepaidCategoryLookups;

namespace Application.Web.Pages.PrepaidCategoryLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PrepaidCategoryLookupUpdateViewModel PrepaidCategoryLookup { get; set; }

        protected IPrepaidCategoryLookupsAppService _prepaidCategoryLookupsAppService;

        public EditModalModelBase(IPrepaidCategoryLookupsAppService prepaidCategoryLookupsAppService)
        {
            _prepaidCategoryLookupsAppService = prepaidCategoryLookupsAppService;

            PrepaidCategoryLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var prepaidCategoryLookup = await _prepaidCategoryLookupsAppService.GetAsync(Id);
            PrepaidCategoryLookup = ObjectMapper.Map<PrepaidCategoryLookupDto, PrepaidCategoryLookupUpdateViewModel>(prepaidCategoryLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _prepaidCategoryLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PrepaidCategoryLookupUpdateViewModel, PrepaidCategoryLookupUpdateDto>(PrepaidCategoryLookup));
            return NoContent();
        }
    }

    public class PrepaidCategoryLookupUpdateViewModel : PrepaidCategoryLookupUpdateDto
    {
    }
}