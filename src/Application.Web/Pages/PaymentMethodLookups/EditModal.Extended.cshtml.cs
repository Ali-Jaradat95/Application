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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IPaymentMethodLookupsAppService paymentMethodLookupsAppService)
            : base(paymentMethodLookupsAppService)
        {
        }
    }
}