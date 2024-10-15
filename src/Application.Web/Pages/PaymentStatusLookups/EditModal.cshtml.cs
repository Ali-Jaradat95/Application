using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PaymentStatusLookups;

namespace Application.Web.Pages.PaymentStatusLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PaymentStatusLookupUpdateViewModel PaymentStatusLookup { get; set; }

        protected IPaymentStatusLookupsAppService _paymentStatusLookupsAppService;

        public EditModalModelBase(IPaymentStatusLookupsAppService paymentStatusLookupsAppService)
        {
            _paymentStatusLookupsAppService = paymentStatusLookupsAppService;

            PaymentStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var paymentStatusLookup = await _paymentStatusLookupsAppService.GetAsync(Id);
            PaymentStatusLookup = ObjectMapper.Map<PaymentStatusLookupDto, PaymentStatusLookupUpdateViewModel>(paymentStatusLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _paymentStatusLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PaymentStatusLookupUpdateViewModel, PaymentStatusLookupUpdateDto>(PaymentStatusLookup));
            return NoContent();
        }
    }

    public class PaymentStatusLookupUpdateViewModel : PaymentStatusLookupUpdateDto
    {
    }
}