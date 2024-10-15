using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.CharSetLookups;

namespace Application.Web.Pages.CharSetLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public CharSetLookupCreateViewModel CharSetLookup { get; set; }

        protected ICharSetLookupsAppService _charSetLookupsAppService;

        public CreateModalModelBase(ICharSetLookupsAppService charSetLookupsAppService)
        {
            _charSetLookupsAppService = charSetLookupsAppService;

            CharSetLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            CharSetLookup = new CharSetLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _charSetLookupsAppService.CreateAsync(ObjectMapper.Map<CharSetLookupCreateViewModel, CharSetLookupCreateDto>(CharSetLookup));
            return NoContent();
        }
    }

    public class CharSetLookupCreateViewModel : CharSetLookupCreateDto
    {
    }
}