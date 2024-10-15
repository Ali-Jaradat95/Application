using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.PrepaidValidationConfigs;

namespace Application.Web.Pages.PrepaidValidationConfigs
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IPrepaidValidationConfigsAppService prepaidValidationConfigsAppService)
            : base(prepaidValidationConfigsAppService)
        {
        }
    }
}