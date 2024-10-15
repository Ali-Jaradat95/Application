using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ThresholdLookups;

namespace Application.Web.Pages.ThresholdLookups
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IThresholdLookupsAppService thresholdLookupsAppService)
            : base(thresholdLookupsAppService)
        {
        }
    }
}