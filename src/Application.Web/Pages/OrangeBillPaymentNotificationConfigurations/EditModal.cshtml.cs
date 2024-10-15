using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.OrangeBillPaymentNotificationConfigurations;

namespace Application.Web.Pages.OrangeBillPaymentNotificationConfigurations
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public OrangeBillPaymentNotificationConfigurationUpdateViewModel OrangeBillPaymentNotificationConfiguration { get; set; }

        protected IOrangeBillPaymentNotificationConfigurationsAppService _orangeBillPaymentNotificationConfigurationsAppService;

        public EditModalModelBase(IOrangeBillPaymentNotificationConfigurationsAppService orangeBillPaymentNotificationConfigurationsAppService)
        {
            _orangeBillPaymentNotificationConfigurationsAppService = orangeBillPaymentNotificationConfigurationsAppService;

            OrangeBillPaymentNotificationConfiguration = new();
        }

        public virtual async Task OnGetAsync()
        {
            var orangeBillPaymentNotificationConfiguration = await _orangeBillPaymentNotificationConfigurationsAppService.GetAsync(Id);
            OrangeBillPaymentNotificationConfiguration = ObjectMapper.Map<OrangeBillPaymentNotificationConfigurationDto, OrangeBillPaymentNotificationConfigurationUpdateViewModel>(orangeBillPaymentNotificationConfiguration);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _orangeBillPaymentNotificationConfigurationsAppService.UpdateAsync(Id, ObjectMapper.Map<OrangeBillPaymentNotificationConfigurationUpdateViewModel, OrangeBillPaymentNotificationConfigurationUpdateDto>(OrangeBillPaymentNotificationConfiguration));
            return NoContent();
        }
    }

    public class OrangeBillPaymentNotificationConfigurationUpdateViewModel : OrangeBillPaymentNotificationConfigurationUpdateDto
    {
    }
}