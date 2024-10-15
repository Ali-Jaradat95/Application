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
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public OrangeBillPaymentNotificationConfigurationCreateViewModel OrangeBillPaymentNotificationConfiguration { get; set; }

        protected IOrangeBillPaymentNotificationConfigurationsAppService _orangeBillPaymentNotificationConfigurationsAppService;

        public CreateModalModelBase(IOrangeBillPaymentNotificationConfigurationsAppService orangeBillPaymentNotificationConfigurationsAppService)
        {
            _orangeBillPaymentNotificationConfigurationsAppService = orangeBillPaymentNotificationConfigurationsAppService;

            OrangeBillPaymentNotificationConfiguration = new();
        }

        public virtual async Task OnGetAsync()
        {
            OrangeBillPaymentNotificationConfiguration = new OrangeBillPaymentNotificationConfigurationCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _orangeBillPaymentNotificationConfigurationsAppService.CreateAsync(ObjectMapper.Map<OrangeBillPaymentNotificationConfigurationCreateViewModel, OrangeBillPaymentNotificationConfigurationCreateDto>(OrangeBillPaymentNotificationConfiguration));
            return NoContent();
        }
    }

    public class OrangeBillPaymentNotificationConfigurationCreateViewModel : OrangeBillPaymentNotificationConfigurationCreateDto
    {
    }
}