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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IPaymentSourceLookupsAppService paymentSourceLookupsAppService)
            : base(paymentSourceLookupsAppService)
        {
        }
    }
}