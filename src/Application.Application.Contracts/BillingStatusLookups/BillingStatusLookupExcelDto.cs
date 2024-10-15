using System;

namespace Application.BillingStatusLookups
{
    public abstract class BillingStatusLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}