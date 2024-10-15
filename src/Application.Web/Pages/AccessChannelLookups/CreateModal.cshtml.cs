using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.AccessChannelLookups;

namespace Application.Web.Pages.AccessChannelLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public AccessChannelLookupCreateViewModel AccessChannelLookup { get; set; }

        protected IAccessChannelLookupsAppService _accessChannelLookupsAppService;

        public CreateModalModelBase(IAccessChannelLookupsAppService accessChannelLookupsAppService)
        {
            _accessChannelLookupsAppService = accessChannelLookupsAppService;

            AccessChannelLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            AccessChannelLookup = new AccessChannelLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _accessChannelLookupsAppService.CreateAsync(ObjectMapper.Map<AccessChannelLookupCreateViewModel, AccessChannelLookupCreateDto>(AccessChannelLookup));
            return NoContent();
        }
    }

    public class AccessChannelLookupCreateViewModel : AccessChannelLookupCreateDto
    {
    }
}