using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.BillingStatusLookups;

namespace Application.Web.Pages.BillingStatusLookups
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IBillingStatusLookupsAppService billingStatusLookupsAppService)
            : base(billingStatusLookupsAppService)
        {
        }
    }
}