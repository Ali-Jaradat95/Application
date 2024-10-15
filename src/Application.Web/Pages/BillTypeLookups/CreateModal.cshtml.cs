using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.BillTypeLookups;

namespace Application.Web.Pages.BillTypeLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public BillTypeLookupCreateViewModel BillTypeLookup { get; set; }

        protected IBillTypeLookupsAppService _billTypeLookupsAppService;

        public CreateModalModelBase(IBillTypeLookupsAppService billTypeLookupsAppService)
        {
            _billTypeLookupsAppService = billTypeLookupsAppService;

            BillTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            BillTypeLookup = new BillTypeLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _billTypeLookupsAppService.CreateAsync(ObjectMapper.Map<BillTypeLookupCreateViewModel, BillTypeLookupCreateDto>(BillTypeLookup));
            return NoContent();
        }
    }

    public class BillTypeLookupCreateViewModel : BillTypeLookupCreateDto
    {
    }
}