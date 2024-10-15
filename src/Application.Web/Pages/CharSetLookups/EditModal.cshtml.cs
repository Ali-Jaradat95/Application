using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.CharSetLookups;

namespace Application.Web.Pages.CharSetLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CharSetLookupUpdateViewModel CharSetLookup { get; set; }

        protected ICharSetLookupsAppService _charSetLookupsAppService;

        public EditModalModelBase(ICharSetLookupsAppService charSetLookupsAppService)
        {
            _charSetLookupsAppService = charSetLookupsAppService;

            CharSetLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var charSetLookup = await _charSetLookupsAppService.GetAsync(Id);
            CharSetLookup = ObjectMapper.Map<CharSetLookupDto, CharSetLookupUpdateViewModel>(charSetLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _charSetLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<CharSetLookupUpdateViewModel, CharSetLookupUpdateDto>(CharSetLookup));
            return NoContent();
        }
    }

    public class CharSetLookupUpdateViewModel : CharSetLookupUpdateDto
    {
    }
}