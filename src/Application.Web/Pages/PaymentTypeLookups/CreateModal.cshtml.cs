using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PaymentTypeLookups;

namespace Application.Web.Pages.PaymentTypeLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PaymentTypeLookupCreateViewModel PaymentTypeLookup { get; set; }

        protected IPaymentTypeLookupsAppService _paymentTypeLookupsAppService;

        public CreateModalModelBase(IPaymentTypeLookupsAppService paymentTypeLookupsAppService)
        {
            _paymentTypeLookupsAppService = paymentTypeLookupsAppService;

            PaymentTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PaymentTypeLookup = new PaymentTypeLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _paymentTypeLookupsAppService.CreateAsync(ObjectMapper.Map<PaymentTypeLookupCreateViewModel, PaymentTypeLookupCreateDto>(PaymentTypeLookup));
            return NoContent();
        }
    }

    public class PaymentTypeLookupCreateViewModel : PaymentTypeLookupCreateDto
    {
    }
}