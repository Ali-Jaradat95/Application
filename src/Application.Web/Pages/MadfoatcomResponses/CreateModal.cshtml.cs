using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.MadfoatcomResponses;

namespace Application.Web.Pages.MadfoatcomResponses
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public MadfoatcomResponseCreateViewModel MadfoatcomResponse { get; set; }

        protected IMadfoatcomResponsesAppService _madfoatcomResponsesAppService;

        public CreateModalModelBase(IMadfoatcomResponsesAppService madfoatcomResponsesAppService)
        {
            _madfoatcomResponsesAppService = madfoatcomResponsesAppService;

            MadfoatcomResponse = new();
        }

        public virtual async Task OnGetAsync()
        {
            MadfoatcomResponse = new MadfoatcomResponseCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _madfoatcomResponsesAppService.CreateAsync(ObjectMapper.Map<MadfoatcomResponseCreateViewModel, MadfoatcomResponseCreateDto>(MadfoatcomResponse));
            return NoContent();
        }
    }

    public class MadfoatcomResponseCreateViewModel : MadfoatcomResponseCreateDto
    {
    }
}