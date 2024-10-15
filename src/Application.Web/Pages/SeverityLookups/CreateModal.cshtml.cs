using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.SeverityLookups;

namespace Application.Web.Pages.SeverityLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public SeverityLookupCreateViewModel SeverityLookup { get; set; }

        protected ISeverityLookupsAppService _severityLookupsAppService;

        public CreateModalModelBase(ISeverityLookupsAppService severityLookupsAppService)
        {
            _severityLookupsAppService = severityLookupsAppService;

            SeverityLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            SeverityLookup = new SeverityLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _severityLookupsAppService.CreateAsync(ObjectMapper.Map<SeverityLookupCreateViewModel, SeverityLookupCreateDto>(SeverityLookup));
            return NoContent();
        }
    }

    public class SeverityLookupCreateViewModel : SeverityLookupCreateDto
    {
    }
}