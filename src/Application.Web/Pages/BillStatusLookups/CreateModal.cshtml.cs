using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.BillStatusLookups;

namespace Application.Web.Pages.BillStatusLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public BillStatusLookupCreateViewModel BillStatusLookup { get; set; }

        protected IBillStatusLookupsAppService _billStatusLookupsAppService;

        public CreateModalModelBase(IBillStatusLookupsAppService billStatusLookupsAppService)
        {
            _billStatusLookupsAppService = billStatusLookupsAppService;

            BillStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            BillStatusLookup = new BillStatusLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _billStatusLookupsAppService.CreateAsync(ObjectMapper.Map<BillStatusLookupCreateViewModel, BillStatusLookupCreateDto>(BillStatusLookup));
            return NoContent();
        }
    }

    public class BillStatusLookupCreateViewModel : BillStatusLookupCreateDto
    {
    }
}