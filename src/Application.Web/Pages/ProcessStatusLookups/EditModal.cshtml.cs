using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.ProcessStatusLookups;

namespace Application.Web.Pages.ProcessStatusLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ProcessStatusLookupUpdateViewModel ProcessStatusLookup { get; set; }

        protected IProcessStatusLookupsAppService _processStatusLookupsAppService;

        public EditModalModelBase(IProcessStatusLookupsAppService processStatusLookupsAppService)
        {
            _processStatusLookupsAppService = processStatusLookupsAppService;

            ProcessStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var processStatusLookup = await _processStatusLookupsAppService.GetAsync(Id);
            ProcessStatusLookup = ObjectMapper.Map<ProcessStatusLookupDto, ProcessStatusLookupUpdateViewModel>(processStatusLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _processStatusLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<ProcessStatusLookupUpdateViewModel, ProcessStatusLookupUpdateDto>(ProcessStatusLookup));
            return NoContent();
        }
    }

    public class ProcessStatusLookupUpdateViewModel : ProcessStatusLookupUpdateDto
    {
    }
}