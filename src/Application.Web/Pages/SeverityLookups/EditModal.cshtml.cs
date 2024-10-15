using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.SeverityLookups;

namespace Application.Web.Pages.SeverityLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public SeverityLookupUpdateViewModel SeverityLookup { get; set; }

        protected ISeverityLookupsAppService _severityLookupsAppService;

        public EditModalModelBase(ISeverityLookupsAppService severityLookupsAppService)
        {
            _severityLookupsAppService = severityLookupsAppService;

            SeverityLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var severityLookup = await _severityLookupsAppService.GetAsync(Id);
            SeverityLookup = ObjectMapper.Map<SeverityLookupDto, SeverityLookupUpdateViewModel>(severityLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _severityLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<SeverityLookupUpdateViewModel, SeverityLookupUpdateDto>(SeverityLookup));
            return NoContent();
        }
    }

    public class SeverityLookupUpdateViewModel : SeverityLookupUpdateDto
    {
    }
}