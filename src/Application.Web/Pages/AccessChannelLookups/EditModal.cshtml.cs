using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.AccessChannelLookups;

namespace Application.Web.Pages.AccessChannelLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public AccessChannelLookupUpdateViewModel AccessChannelLookup { get; set; }

        protected IAccessChannelLookupsAppService _accessChannelLookupsAppService;

        public EditModalModelBase(IAccessChannelLookupsAppService accessChannelLookupsAppService)
        {
            _accessChannelLookupsAppService = accessChannelLookupsAppService;

            AccessChannelLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var accessChannelLookup = await _accessChannelLookupsAppService.GetAsync(Id);
            AccessChannelLookup = ObjectMapper.Map<AccessChannelLookupDto, AccessChannelLookupUpdateViewModel>(accessChannelLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _accessChannelLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<AccessChannelLookupUpdateViewModel, AccessChannelLookupUpdateDto>(AccessChannelLookup));
            return NoContent();
        }
    }

    public class AccessChannelLookupUpdateViewModel : AccessChannelLookupUpdateDto
    {
    }
}