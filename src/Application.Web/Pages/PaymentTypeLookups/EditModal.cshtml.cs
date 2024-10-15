using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PaymentTypeLookups;

namespace Application.Web.Pages.PaymentTypeLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PaymentTypeLookupUpdateViewModel PaymentTypeLookup { get; set; }

        protected IPaymentTypeLookupsAppService _paymentTypeLookupsAppService;

        public EditModalModelBase(IPaymentTypeLookupsAppService paymentTypeLookupsAppService)
        {
            _paymentTypeLookupsAppService = paymentTypeLookupsAppService;

            PaymentTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var paymentTypeLookup = await _paymentTypeLookupsAppService.GetAsync(Id);
            PaymentTypeLookup = ObjectMapper.Map<PaymentTypeLookupDto, PaymentTypeLookupUpdateViewModel>(paymentTypeLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _paymentTypeLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PaymentTypeLookupUpdateViewModel, PaymentTypeLookupUpdateDto>(PaymentTypeLookup));
            return NoContent();
        }
    }

    public class PaymentTypeLookupUpdateViewModel : PaymentTypeLookupUpdateDto
    {
    }
}