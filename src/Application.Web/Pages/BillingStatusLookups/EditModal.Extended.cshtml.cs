using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.BillingStatusLookups;

namespace Application.Web.Pages.BillingStatusLookups
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IBillingStatusLookupsAppService billingStatusLookupsAppService)
            : base(billingStatusLookupsAppService)
        {
        }
    }
}