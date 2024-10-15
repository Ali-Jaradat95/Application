using System;

namespace Application.PrepaidCategoryLookups
{
    public abstract class PrepaidCategoryLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}