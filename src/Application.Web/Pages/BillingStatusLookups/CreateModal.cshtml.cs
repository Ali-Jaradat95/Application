using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.BillingStatusLookups;

namespace Application.Web.Pages.BillingStatusLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public BillingStatusLookupCreateViewModel BillingStatusLookup { get; set; }

        protected IBillingStatusLookupsAppService _billingStatusLookupsAppService;

        public CreateModalModelBase(IBillingStatusLookupsAppService billingStatusLookupsAppService)
        {
            _billingStatusLookupsAppService = billingStatusLookupsAppService;

            BillingStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            BillingStatusLookup = new BillingStatusLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _billingStatusLookupsAppService.CreateAsync(ObjectMapper.Map<BillingStatusLookupCreateViewModel, BillingStatusLookupCreateDto>(BillingStatusLookup));
            return NoContent();
        }
    }

    public class BillingStatusLookupCreateViewModel : BillingStatusLookupCreateDto
    {
    }
}