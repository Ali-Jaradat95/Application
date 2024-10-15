using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.MadfoatcomRequests;

namespace Application.Web.Pages.MadfoatcomRequests
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public MadfoatcomRequestUpdateViewModel MadfoatcomRequest { get; set; }

        protected IMadfoatcomRequestsAppService _madfoatcomRequestsAppService;

        public EditModalModelBase(IMadfoatcomRequestsAppService madfoatcomRequestsAppService)
        {
            _madfoatcomRequestsAppService = madfoatcomRequestsAppService;

            MadfoatcomRequest = new();
        }

        public virtual async Task OnGetAsync()
        {
            var madfoatcomRequest = await _madfoatcomRequestsAppService.GetAsync(Id);
            MadfoatcomRequest = ObjectMapper.Map<MadfoatcomRequestDto, MadfoatcomRequestUpdateViewModel>(madfoatcomRequest);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _madfoatcomRequestsAppService.UpdateAsync(Id, ObjectMapper.Map<MadfoatcomRequestUpdateViewModel, MadfoatcomRequestUpdateDto>(MadfoatcomRequest));
            return NoContent();
        }
    }

    public class MadfoatcomRequestUpdateViewModel : MadfoatcomRequestUpdateDto
    {
    }
}