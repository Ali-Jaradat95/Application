using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.BillTypeLookups;

namespace Application.Web.Pages.BillTypeLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public BillTypeLookupUpdateViewModel BillTypeLookup { get; set; }

        protected IBillTypeLookupsAppService _billTypeLookupsAppService;

        public EditModalModelBase(IBillTypeLookupsAppService billTypeLookupsAppService)
        {
            _billTypeLookupsAppService = billTypeLookupsAppService;

            BillTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var billTypeLookup = await _billTypeLookupsAppService.GetAsync(Id);
            BillTypeLookup = ObjectMapper.Map<BillTypeLookupDto, BillTypeLookupUpdateViewModel>(billTypeLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _billTypeLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<BillTypeLookupUpdateViewModel, BillTypeLookupUpdateDto>(BillTypeLookup));
            return NoContent();
        }
    }

    public class BillTypeLookupUpdateViewModel : BillTypeLookupUpdateDto
    {
    }
}