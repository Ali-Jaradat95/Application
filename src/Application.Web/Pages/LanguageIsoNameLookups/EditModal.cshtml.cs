using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.LanguageIsoNameLookups;

namespace Application.Web.Pages.LanguageIsoNameLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public LanguageIsoNameLookupUpdateViewModel LanguageIsoNameLookup { get; set; }

        protected ILanguageIsoNameLookupsAppService _languageIsoNameLookupsAppService;

        public EditModalModelBase(ILanguageIsoNameLookupsAppService languageIsoNameLookupsAppService)
        {
            _languageIsoNameLookupsAppService = languageIsoNameLookupsAppService;

            LanguageIsoNameLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var languageIsoNameLookup = await _languageIsoNameLookupsAppService.GetAsync(Id);
            LanguageIsoNameLookup = ObjectMapper.Map<LanguageIsoNameLookupDto, LanguageIsoNameLookupUpdateViewModel>(languageIsoNameLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _languageIsoNameLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<LanguageIsoNameLookupUpdateViewModel, LanguageIsoNameLookupUpdateDto>(LanguageIsoNameLookup));
            return NoContent();
        }
    }

    public class LanguageIsoNameLookupUpdateViewModel : LanguageIsoNameLookupUpdateDto
    {
    }
}