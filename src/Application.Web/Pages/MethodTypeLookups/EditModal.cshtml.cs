using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.MethodTypeLookups;

namespace Application.Web.Pages.MethodTypeLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public MethodTypeLookupUpdateViewModel MethodTypeLookup { get; set; }

        protected IMethodTypeLookupsAppService _methodTypeLookupsAppService;

        public EditModalModelBase(IMethodTypeLookupsAppService methodTypeLookupsAppService)
        {
            _methodTypeLookupsAppService = methodTypeLookupsAppService;

            MethodTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var methodTypeLookup = await _methodTypeLookupsAppService.GetAsync(Id);
            MethodTypeLookup = ObjectMapper.Map<MethodTypeLookupDto, MethodTypeLookupUpdateViewModel>(methodTypeLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _methodTypeLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<MethodTypeLookupUpdateViewModel, MethodTypeLookupUpdateDto>(MethodTypeLookup));
            return NoContent();
        }
    }

    public class MethodTypeLookupUpdateViewModel : MethodTypeLookupUpdateDto
    {
    }
}