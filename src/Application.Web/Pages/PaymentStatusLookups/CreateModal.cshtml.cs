using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PaymentStatusLookups;

namespace Application.Web.Pages.PaymentStatusLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PaymentStatusLookupCreateViewModel PaymentStatusLookup { get; set; }

        protected IPaymentStatusLookupsAppService _paymentStatusLookupsAppService;

        public CreateModalModelBase(IPaymentStatusLookupsAppService paymentStatusLookupsAppService)
        {
            _paymentStatusLookupsAppService = paymentStatusLookupsAppService;

            PaymentStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            PaymentStatusLookup = new PaymentStatusLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _paymentStatusLookupsAppService.CreateAsync(ObjectMapper.Map<PaymentStatusLookupCreateViewModel, PaymentStatusLookupCreateDto>(PaymentStatusLookup));
            return NoContent();
        }
    }

    public class PaymentStatusLookupCreateViewModel : PaymentStatusLookupCreateDto
    {
    }
}