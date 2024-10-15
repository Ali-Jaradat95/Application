using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.OrangeBillPullServiceConfigurations;

namespace Application.Web.Pages.OrangeBillPullServiceConfigurations
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public OrangeBillPullServiceConfigurationCreateViewModel OrangeBillPullServiceConfiguration { get; set; }

        protected IOrangeBillPullServiceConfigurationsAppService _orangeBillPullServiceConfigurationsAppService;

        public CreateModalModelBase(IOrangeBillPullServiceConfigurationsAppService orangeBillPullServiceConfigurationsAppService)
        {
            _orangeBillPullServiceConfigurationsAppService = orangeBillPullServiceConfigurationsAppService;

            OrangeBillPullServiceConfiguration = new();
        }

        public virtual async Task OnGetAsync()
        {
            OrangeBillPullServiceConfiguration = new OrangeBillPullServiceConfigurationCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _orangeBillPullServiceConfigurationsAppService.CreateAsync(ObjectMapper.Map<OrangeBillPullServiceConfigurationCreateViewModel, OrangeBillPullServiceConfigurationCreateDto>(OrangeBillPullServiceConfiguration));
            return NoContent();
        }
    }

    public class OrangeBillPullServiceConfigurationCreateViewModel : OrangeBillPullServiceConfigurationCreateDto
    {
    }
}