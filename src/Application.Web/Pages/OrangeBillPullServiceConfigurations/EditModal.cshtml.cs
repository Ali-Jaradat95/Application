using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.OrangeBillPullServiceConfigurations;

namespace Application.Web.Pages.OrangeBillPullServiceConfigurations
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public OrangeBillPullServiceConfigurationUpdateViewModel OrangeBillPullServiceConfiguration { get; set; }

        protected IOrangeBillPullServiceConfigurationsAppService _orangeBillPullServiceConfigurationsAppService;

        public EditModalModelBase(IOrangeBillPullServiceConfigurationsAppService orangeBillPullServiceConfigurationsAppService)
        {
            _orangeBillPullServiceConfigurationsAppService = orangeBillPullServiceConfigurationsAppService;

            OrangeBillPullServiceConfiguration = new();
        }

        public virtual async Task OnGetAsync()
        {
            var orangeBillPullServiceConfiguration = await _orangeBillPullServiceConfigurationsAppService.GetAsync(Id);
            OrangeBillPullServiceConfiguration = ObjectMapper.Map<OrangeBillPullServiceConfigurationDto, OrangeBillPullServiceConfigurationUpdateViewModel>(orangeBillPullServiceConfiguration);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _orangeBillPullServiceConfigurationsAppService.UpdateAsync(Id, ObjectMapper.Map<OrangeBillPullServiceConfigurationUpdateViewModel, OrangeBillPullServiceConfigurationUpdateDto>(OrangeBillPullServiceConfiguration));
            return NoContent();
        }
    }

    public class OrangeBillPullServiceConfigurationUpdateViewModel : OrangeBillPullServiceConfigurationUpdateDto
    {
    }
}