using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PaymentCurrencyLookups;

namespace Application.Web.Pages.PaymentCurrencyLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PaymentCurrencyLookupCreateViewModel PaymentCurrencyLookup { get; set; }

        protected IPaymentCurrencyLookupsAppService _paymentCurrencyLookupsAppService;

        public CreateModalModelBase(IPaymentCurrencyLookupsAppService paymentCurrencyLookupsAppService)
        {
            _paymentCurrencyLookupsAppService = paymentCurrencyLookupsAppService;

            PaymentCurrencyLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PaymentCurrencyLookup = new PaymentCurrencyLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _paymentCurrencyLookupsAppService.CreateAsync(ObjectMapper.Map<PaymentCurrencyLookupCreateViewModel, PaymentCurrencyLookupCreateDto>(PaymentCurrencyLookup));
            return NoContent();
        }
    }

    public class PaymentCurrencyLookupCreateViewModel : PaymentCurrencyLookupCreateDto
    {
    }
}