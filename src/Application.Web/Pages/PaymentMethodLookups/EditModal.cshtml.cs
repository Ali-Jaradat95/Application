using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PaymentMethodLookups;

namespace Application.Web.Pages.PaymentMethodLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PaymentMethodLookupUpdateViewModel PaymentMethodLookup { get; set; }

        protected IPaymentMethodLookupsAppService _paymentMethodLookupsAppService;

        public EditModalModelBase(IPaymentMethodLookupsAppService paymentMethodLookupsAppService)
        {
            _paymentMethodLookupsAppService = paymentMethodLookupsAppService;

            PaymentMethodLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var paymentMethodLookup = await _paymentMethodLookupsAppService.GetAsync(Id);
            PaymentMethodLookup = ObjectMapper.Map<PaymentMethodLookupDto, PaymentMethodLookupUpdateViewModel>(paymentMethodLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _paymentMethodLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PaymentMethodLookupUpdateViewModel, PaymentMethodLookupUpdateDto>(PaymentMethodLookup));
            return NoContent();
        }
    }

    public class PaymentMethodLookupUpdateViewModel : PaymentMethodLookupUpdateDto
    {
    }
}