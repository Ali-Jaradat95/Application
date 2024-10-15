using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.OperationTypeLookups;

namespace Application.Web.Pages.OperationTypeLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public OperationTypeLookupCreateViewModel OperationTypeLookup { get; set; }

        protected IOperationTypeLookupsAppService _operationTypeLookupsAppService;

        public CreateModalModelBase(IOperationTypeLookupsAppService operationTypeLookupsAppService)
        {
            _operationTypeLookupsAppService = operationTypeLookupsAppService;

            OperationTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            OperationTypeLookup = new OperationTypeLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _operationTypeLookupsAppService.CreateAsync(ObjectMapper.Map<OperationTypeLookupCreateViewModel, OperationTypeLookupCreateDto>(OperationTypeLookup));
            return NoContent();
        }
    }

    public class OperationTypeLookupCreateViewModel : OperationTypeLookupCreateDto
    {
    }
}