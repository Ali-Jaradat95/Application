using Volo.Abp.Application.Dtos;
using System;

namespace Application.BillingStatusLookups
{
    public abstract class GetBillingStatusLookupsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetBillingStatusLookupsInputBase()
        {

        }
    }
}