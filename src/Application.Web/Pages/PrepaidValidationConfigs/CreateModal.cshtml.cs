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
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public PrepaidValidationConfigCreateViewModel PrepaidValidationConfig { get; set; }

        protected IPrepaidValidationConfigsAppService _prepaidValidationConfigsAppService;

        public CreateModalModelBase(IPrepaidValidationConfigsAppService prepaidValidationConfigsAppService)
        {
            _prepaidValidationConfigsAppService = prepaidValidationConfigsAppService;

            PrepaidValidationConfig = new();
        }

        public virtual async Task OnGetAsync()
        {
            PrepaidValidationConfig = new PrepaidValidationConfigCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _prepaidValidationConfigsAppService.CreateAsync(ObjectMapper.Map<PrepaidValidationConfigCreateViewModel, PrepaidValidationConfigCreateDto>(PrepaidValidationConfig));
            return NoContent();
        }
    }

    public class PrepaidValidationConfigCreateViewModel : PrepaidValidationConfigCreateDto
    {
    }
}