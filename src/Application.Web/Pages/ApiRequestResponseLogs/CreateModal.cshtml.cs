using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ApiRequestResponseLogs;

namespace Application.Web.Pages.ApiRequestResponseLogs
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public ApiRequestResponseLogCreateViewModel ApiRequestResponseLog { get; set; }

        protected IApiRequestResponseLogsAppService _apiRequestResponseLogsAppService;

        public CreateModalModelBase(IApiRequestResponseLogsAppService apiRequestResponseLogsAppService)
        {
            _apiRequestResponseLogsAppService = apiRequestResponseLogsAppService;

            ApiRequestResponseLog = new();
        }

        public virtual async Task OnGetAsync()
        {
            ApiRequestResponseLog = new ApiRequestResponseLogCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _apiRequestResponseLogsAppService.CreateAsync(ObjectMapper.Map<ApiRequestResponseLogCreateViewModel, ApiRequestResponseLogCreateDto>(ApiRequestResponseLog));
            return NoContent();
        }
    }

    public class ApiRequestResponseLogCreateViewModel : ApiRequestResponseLogCreateDto
    {
    }
}