using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PaymentSourceLookups;

namespace Application.Web.Pages.PaymentSourceLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PaymentSourceLookupUpdateViewModel PaymentSourceLookup { get; set; }

        protected IPaymentSourceLookupsAppService _paymentSourceLookupsAppService;

        public EditModalModelBase(IPaymentSourceLookupsAppService paymentSourceLookupsAppService)
        {
            _paymentSourceLookupsAppService = paymentSourceLookupsAppService;

            PaymentSourceLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var paymentSourceLookup = await _paymentSourceLookupsAppService.GetAsync(Id);
            PaymentSourceLookup = ObjectMapper.Map<PaymentSourceLookupDto, PaymentSourceLookupUpdateViewModel>(paymentSourceLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _paymentSourceLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<PaymentSourceLookupUpdateViewModel, PaymentSourceLookupUpdateDto>(PaymentSourceLookup));
            return NoContent();
        }
    }

    public class PaymentSourceLookupUpdateViewModel : PaymentSourceLookupUpdateDto
    {
    }
}