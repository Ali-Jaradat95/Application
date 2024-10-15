using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.OrangeBillPaymentNotificationConfigurations;

namespace Application.Web.Pages.OrangeBillPaymentNotificationConfigurations
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IOrangeBillPaymentNotificationConfigurationsAppService orangeBillPaymentNotificationConfigurationsAppService)
            : base(orangeBillPaymentNotificationConfigurationsAppService)
        {
        }
    }
}