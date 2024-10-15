using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.BillStatusLookups;

namespace Application.Web.Pages.BillStatusLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public BillStatusLookupUpdateViewModel BillStatusLookup { get; set; }

        protected IBillStatusLookupsAppService _billStatusLookupsAppService;

        public EditModalModelBase(IBillStatusLookupsAppService billStatusLookupsAppService)
        {
            _billStatusLookupsAppService = billStatusLookupsAppService;

            BillStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var billStatusLookup = await _billStatusLookupsAppService.GetAsync(Id);
            BillStatusLookup = ObjectMapper.Map<BillStatusLookupDto, BillStatusLookupUpdateViewModel>(billStatusLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _billStatusLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<BillStatusLookupUpdateViewModel, BillStatusLookupUpdateDto>(BillStatusLookup));
            return NoContent();
        }
    }

    public class BillStatusLookupUpdateViewModel : BillStatusLookupUpdateDto
    {
    }
}