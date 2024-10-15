using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.MethodTypeLookups;

namespace Application.Web.Pages.MethodTypeLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public MethodTypeLookupCreateViewModel MethodTypeLookup { get; set; }

        protected IMethodTypeLookupsAppService _methodTypeLookupsAppService;

        public CreateModalModelBase(IMethodTypeLookupsAppService methodTypeLookupsAppService)
        {
            _methodTypeLookupsAppService = methodTypeLookupsAppService;

            MethodTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            MethodTypeLookup = new MethodTypeLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _methodTypeLookupsAppService.CreateAsync(ObjectMapper.Map<MethodTypeLookupCreateViewModel, MethodTypeLookupCreateDto>(MethodTypeLookup));
            return NoContent();
        }
    }

    public class MethodTypeLookupCreateViewModel : MethodTypeLookupCreateDto
    {
    }
}