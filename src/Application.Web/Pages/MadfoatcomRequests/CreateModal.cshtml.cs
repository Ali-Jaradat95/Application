using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.MadfoatcomRequests;

namespace Application.Web.Pages.MadfoatcomRequests
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public MadfoatcomRequestCreateViewModel MadfoatcomRequest { get; set; }

        protected IMadfoatcomRequestsAppService _madfoatcomRequestsAppService;

        public CreateModalModelBase(IMadfoatcomRequestsAppService madfoatcomRequestsAppService)
        {
            _madfoatcomRequestsAppService = madfoatcomRequestsAppService;

            MadfoatcomRequest = new();
        }

        public virtual async Task OnGetAsync()
        {
            MadfoatcomRequest = new MadfoatcomRequestCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _madfoatcomRequestsAppService.CreateAsync(ObjectMapper.Map<MadfoatcomRequestCreateViewModel, MadfoatcomRequestCreateDto>(MadfoatcomRequest));
            return NoContent();
        }
    }

    public class MadfoatcomRequestCreateViewModel : MadfoatcomRequestCreateDto
    {
    }
}