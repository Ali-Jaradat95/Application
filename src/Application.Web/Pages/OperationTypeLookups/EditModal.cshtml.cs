using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.OperationTypeLookups;

namespace Application.Web.Pages.OperationTypeLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public OperationTypeLookupUpdateViewModel OperationTypeLookup { get; set; }

        protected IOperationTypeLookupsAppService _operationTypeLookupsAppService;

        public EditModalModelBase(IOperationTypeLookupsAppService operationTypeLookupsAppService)
        {
            _operationTypeLookupsAppService = operationTypeLookupsAppService;

            OperationTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var operationTypeLookup = await _operationTypeLookupsAppService.GetAsync(Id);
            OperationTypeLookup = ObjectMapper.Map<OperationTypeLookupDto, OperationTypeLookupUpdateViewModel>(operationTypeLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _operationTypeLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<OperationTypeLookupUpdateViewModel, OperationTypeLookupUpdateDto>(OperationTypeLookup));
            return NoContent();
        }
    }

    public class OperationTypeLookupUpdateViewModel : OperationTypeLookupUpdateDto
    {
    }
}