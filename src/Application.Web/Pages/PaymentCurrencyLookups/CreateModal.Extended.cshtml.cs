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
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IPaymentCurrencyLookupsAppService paymentCurrencyLookupsAppService)
            : base(paymentCurrencyLookupsAppService)
        {
        }
    }
}