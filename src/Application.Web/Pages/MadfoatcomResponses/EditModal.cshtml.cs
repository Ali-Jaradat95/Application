using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.MadfoatcomResponses;

namespace Application.Web.Pages.MadfoatcomResponses
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public MadfoatcomResponseUpdateViewModel MadfoatcomResponse { get; set; }

        protected IMadfoatcomResponsesAppService _madfoatcomResponsesAppService;

        public EditModalModelBase(IMadfoatcomResponsesAppService madfoatcomResponsesAppService)
        {
            _madfoatcomResponsesAppService = madfoatcomResponsesAppService;

            MadfoatcomResponse = new();
        }

        public virtual async Task OnGetAsync()
        {
            var madfoatcomResponse = await _madfoatcomResponsesAppService.GetAsync(Id);
            MadfoatcomResponse = ObjectMapper.Map<MadfoatcomResponseDto, MadfoatcomResponseUpdateViewModel>(madfoatcomResponse);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _madfoatcomResponsesAppService.UpdateAsync(Id, ObjectMapper.Map<MadfoatcomResponseUpdateViewModel, MadfoatcomResponseUpdateDto>(MadfoatcomResponse));
            return NoContent();
        }
    }

    public class MadfoatcomResponseUpdateViewModel : MadfoatcomResponseUpdateDto
    {
    }
}