using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.PrepaidValidationConfigs;

namespace Application.Web.Pages.PrepaidValidationConfigs
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IPrepaidValidationConfigsAppService prepaidValidationConfigsAppService)
            : base(prepaidValidationConfigsAppService)
        {
        }
    }
}