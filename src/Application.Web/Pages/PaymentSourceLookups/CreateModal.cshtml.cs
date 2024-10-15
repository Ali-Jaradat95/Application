using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PaymentSourceLookups;

namespace Application.Web.Pages.PaymentSourceLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PaymentSourceLookupCreateViewModel PaymentSourceLookup { get; set; }

        protected IPaymentSourceLookupsAppService _paymentSourceLookupsAppService;

        public CreateModalModelBase(IPaymentSourceLookupsAppService paymentSourceLookupsAppService)
        {
            _paymentSourceLookupsAppService = paymentSourceLookupsAppService;

            PaymentSourceLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PaymentSourceLookup = new PaymentSourceLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _paymentSourceLookupsAppService.CreateAsync(ObjectMapper.Map<PaymentSourceLookupCreateViewModel, PaymentSourceLookupCreateDto>(PaymentSourceLookup));
            return NoContent();
        }
    }

    public class PaymentSourceLookupCreateViewModel : PaymentSourceLookupCreateDto
    {
    }
}