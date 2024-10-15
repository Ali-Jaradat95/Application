using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.ThresholdLookups;

namespace Application.Web.Pages.ThresholdLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ThresholdLookupUpdateViewModel ThresholdLookup { get; set; }

        protected IThresholdLookupsAppService _thresholdLookupsAppService;

        public EditModalModelBase(IThresholdLookupsAppService thresholdLookupsAppService)
        {
            _thresholdLookupsAppService = thresholdLookupsAppService;

            ThresholdLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var thresholdLookup = await _thresholdLookupsAppService.GetAsync(Id);
            ThresholdLookup = ObjectMapper.Map<ThresholdLookupDto, ThresholdLookupUpdateViewModel>(thresholdLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _thresholdLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<ThresholdLookupUpdateViewModel, ThresholdLookupUpdateDto>(ThresholdLookup));
            return NoContent();
        }
    }

    public class ThresholdLookupUpdateViewModel : ThresholdLookupUpdateDto
    {
    }
}