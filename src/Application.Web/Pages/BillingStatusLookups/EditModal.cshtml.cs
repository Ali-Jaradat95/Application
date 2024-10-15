using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.BillingStatusLookups;

namespace Application.Web.Pages.BillingStatusLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public BillingStatusLookupUpdateViewModel BillingStatusLookup { get; set; }

        protected IBillingStatusLookupsAppService _billingStatusLookupsAppService;

        public EditModalModelBase(IBillingStatusLookupsAppService billingStatusLookupsAppService)
        {
            _billingStatusLookupsAppService = billingStatusLookupsAppService;

            BillingStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var billingStatusLookup = await _billingStatusLookupsAppService.GetAsync(Id);
            BillingStatusLookup = ObjectMapper.Map<BillingStatusLookupDto, BillingStatusLookupUpdateViewModel>(billingStatusLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _billingStatusLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<BillingStatusLookupUpdateViewModel, BillingStatusLookupUpdateDto>(BillingStatusLookup));
            return NoContent();
        }
    }

    public class BillingStatusLookupUpdateViewModel : BillingStatusLookupUpdateDto
    {
    }
}