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
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public PrepaidValidationConfigUpdateViewModel PrepaidValidationConfig { get; set; }

        protected IPrepaidValidationConfigsAppService _prepaidValidationConfigsAppService;

        public EditModalModelBase(IPrepaidValidationConfigsAppService prepaidValidationConfigsAppService)
        {
            _prepaidValidationConfigsAppService = prepaidValidationConfigsAppService;

            PrepaidValidationConfig = new();
        }

        public virtual async Task OnGetAsync()
        {
            var prepaidValidationConfig = await _prepaidValidationConfigsAppService.GetAsync(Id);
            PrepaidValidationConfig = ObjectMapper.Map<PrepaidValidationConfigDto, PrepaidValidationConfigUpdateViewModel>(prepaidValidationConfig);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _prepaidValidationConfigsAppService.UpdateAsync(Id, ObjectMapper.Map<PrepaidValidationConfigUpdateViewModel, PrepaidValidationConfigUpdateDto>(PrepaidValidationConfig));
            return NoContent();
        }
    }

    public class PrepaidValidationConfigUpdateViewModel : PrepaidValidationConfigUpdateDto
    {
    }
}