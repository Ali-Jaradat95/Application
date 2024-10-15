using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ServiceTypeLookups;

namespace Application.Web.Pages.ServiceTypeLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public ServiceTypeLookupCreateViewModel ServiceTypeLookup { get; set; }

        protected IServiceTypeLookupsAppService _serviceTypeLookupsAppService;

        public CreateModalModelBase(IServiceTypeLookupsAppService serviceTypeLookupsAppService)
        {
            _serviceTypeLookupsAppService = serviceTypeLookupsAppService;

            ServiceTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            ServiceTypeLookup = new ServiceTypeLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _serviceTypeLookupsAppService.CreateAsync(ObjectMapper.Map<ServiceTypeLookupCreateViewModel, ServiceTypeLookupCreateDto>(ServiceTypeLookup));
            return NoContent();
        }
    }

    public class ServiceTypeLookupCreateViewModel : ServiceTypeLookupCreateDto
    {
    }
}