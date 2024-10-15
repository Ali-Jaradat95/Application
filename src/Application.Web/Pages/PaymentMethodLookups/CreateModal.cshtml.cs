using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PaymentMethodLookups;

namespace Application.Web.Pages.PaymentMethodLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PaymentMethodLookupCreateViewModel PaymentMethodLookup { get; set; }

        protected IPaymentMethodLookupsAppService _paymentMethodLookupsAppService;

        public CreateModalModelBase(IPaymentMethodLookupsAppService paymentMethodLookupsAppService)
        {
            _paymentMethodLookupsAppService = paymentMethodLookupsAppService;

            PaymentMethodLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PaymentMethodLookup = new PaymentMethodLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _paymentMethodLookupsAppService.CreateAsync(ObjectMapper.Map<PaymentMethodLookupCreateViewModel, PaymentMethodLookupCreateDto>(PaymentMethodLookup));
            return NoContent();
        }
    }

    public class PaymentMethodLookupCreateViewModel : PaymentMethodLookupCreateDto
    {
    }
}