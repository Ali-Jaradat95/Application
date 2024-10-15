using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.ApiRequestResponseLogs;

namespace Application.Web.Pages.ApiRequestResponseLogs
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ApiRequestResponseLogUpdateViewModel ApiRequestResponseLog { get; set; }

        protected IApiRequestResponseLogsAppService _apiRequestResponseLogsAppService;

        public EditModalModelBase(IApiRequestResponseLogsAppService apiRequestResponseLogsAppService)
        {
            _apiRequestResponseLogsAppService = apiRequestResponseLogsAppService;

            ApiRequestResponseLog = new();
        }

        public virtual async Task OnGetAsync()
        {
            var apiRequestResponseLog = await _apiRequestResponseLogsAppService.GetAsync(Id);
            ApiRequestResponseLog = ObjectMapper.Map<ApiRequestResponseLogDto, ApiRequestResponseLogUpdateViewModel>(apiRequestResponseLog);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _apiRequestResponseLogsAppService.UpdateAsync(Id, ObjectMapper.Map<ApiRequestResponseLogUpdateViewModel, ApiRequestResponseLogUpdateDto>(ApiRequestResponseLog));
            return NoContent();
        }
    }

    public class ApiRequestResponseLogUpdateViewModel : ApiRequestResponseLogUpdateDto
    {
    }
}