using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ProcessStatusLookups;

namespace Application.Web.Pages.ProcessStatusLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public ProcessStatusLookupCreateViewModel ProcessStatusLookup { get; set; }

        protected IProcessStatusLookupsAppService _processStatusLookupsAppService;

        public CreateModalModelBase(IProcessStatusLookupsAppService processStatusLookupsAppService)
        {
            _processStatusLookupsAppService = processStatusLookupsAppService;

            ProcessStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            ProcessStatusLookup = new ProcessStatusLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _processStatusLookupsAppService.CreateAsync(ObjectMapper.Map<ProcessStatusLookupCreateViewModel, ProcessStatusLookupCreateDto>(ProcessStatusLookup));
            return NoContent();
        }
    }

    public class ProcessStatusLookupCreateViewModel : ProcessStatusLookupCreateDto
    {
    }
}