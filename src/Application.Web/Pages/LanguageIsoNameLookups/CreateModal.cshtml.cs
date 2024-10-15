using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.LanguageIsoNameLookups;

namespace Application.Web.Pages.LanguageIsoNameLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public LanguageIsoNameLookupCreateViewModel LanguageIsoNameLookup { get; set; }

        protected ILanguageIsoNameLookupsAppService _languageIsoNameLookupsAppService;

        public CreateModalModelBase(ILanguageIsoNameLookupsAppService languageIsoNameLookupsAppService)
        {
            _languageIsoNameLookupsAppService = languageIsoNameLookupsAppService;

            LanguageIsoNameLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            LanguageIsoNameLookup = new LanguageIsoNameLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _languageIsoNameLookupsAppService.CreateAsync(ObjectMapper.Map<LanguageIsoNameLookupCreateViewModel, LanguageIsoNameLookupCreateDto>(LanguageIsoNameLookup));
            return NoContent();
        }
    }

    public class LanguageIsoNameLookupCreateViewModel : LanguageIsoNameLookupCreateDto
    {
    }
}