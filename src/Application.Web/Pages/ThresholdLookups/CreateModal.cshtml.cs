using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ThresholdLookups;

namespace Application.Web.Pages.ThresholdLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public ThresholdLookupCreateViewModel ThresholdLookup { get; set; }

        protected IThresholdLookupsAppService _thresholdLookupsAppService;

        public CreateModalModelBase(IThresholdLookupsAppService thresholdLookupsAppService)
        {
            _thresholdLookupsAppService = thresholdLookupsAppService;

            ThresholdLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            ThresholdLookup = new ThresholdLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _thresholdLookupsAppService.CreateAsync(ObjectMapper.Map<ThresholdLookupCreateViewModel, ThresholdLookupCreateDto>(ThresholdLookup));
            return NoContent();
        }
    }

    public class ThresholdLookupCreateViewModel : ThresholdLookupCreateDto
    {
    }
}