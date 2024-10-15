using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PaymentCurrencyLookups;

namespace Application.Web.Pages.PaymentCurrencyLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PaymentCurrencyLookupUpdateViewModel PaymentCurrencyLookup { get; set; }

        protected IPaymentCurrencyLookupsAppService _paymentCurrencyLookupsAppService;

        public EditModalModelBase(IPaymentCurrencyLookupsAppService paymentCurrencyLookupsAppService)
        {
            _paymentCurrencyLookupsAppService = paymentCurrencyLookupsAppService;

            PaymentCurrencyLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var paymentCurrencyLookup = await _paymentCurrencyLookupsAppService.GetAsync(Id);
            PaymentCurrencyLookup = ObjectMapper.Map<PaymentCurrencyLookupDto, PaymentCurrencyLookupUpdateViewModel>(paymentCurrencyLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _paymentCurrencyLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PaymentCurrencyLookupUpdateViewModel, PaymentCurrencyLookupUpdateDto>(PaymentCurrencyLookup));
            return NoContent();
        }
    }

    public class PaymentCurrencyLookupUpdateViewModel : PaymentCurrencyLookupUpdateDto
    {
    }
}