using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.ServiceTypeLookups;

namespace Application.Web.Pages.ServiceTypeLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ServiceTypeLookupUpdateViewModel ServiceTypeLookup { get; set; }

        protected IServiceTypeLookupsAppService _serviceTypeLookupsAppService;

        public EditModalModelBase(IServiceTypeLookupsAppService serviceTypeLookupsAppService)
        {
            _serviceTypeLookupsAppService = serviceTypeLookupsAppService;

            ServiceTypeLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var serviceTypeLookup = await _serviceTypeLookupsAppService.GetAsync(Id);
            ServiceTypeLookup = ObjectMapper.Map<ServiceTypeLookupDto, ServiceTypeLookupUpdateViewModel>(serviceTypeLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _serviceTypeLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<ServiceTypeLookupUpdateViewModel, ServiceTypeLookupUpdateDto>(ServiceTypeLookup));
            return NoContent();
        }
    }

    public class ServiceTypeLookupUpdateViewModel : ServiceTypeLookupUpdateDto
    {
    }
}