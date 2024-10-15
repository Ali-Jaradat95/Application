using Volo.Abp.Application.Dtos;
using System;

namespace Application.PrepaidCategoryLookups
{
    public abstract class GetPrepaidCategoryLookupsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetPrepaidCategoryLookupsInputBase()
        {

        }
    }
}