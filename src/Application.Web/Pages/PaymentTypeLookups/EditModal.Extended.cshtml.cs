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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IPaymentTypeLookupsAppService paymentTypeLookupsAppService)
            : base(paymentTypeLookupsAppService)
        {
        }
    }
}