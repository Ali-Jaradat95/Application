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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IPaymentCurrencyLookupsAppService paymentCurrencyLookupsAppService)
            : base(paymentCurrencyLookupsAppService)
        {
        }
    }
}