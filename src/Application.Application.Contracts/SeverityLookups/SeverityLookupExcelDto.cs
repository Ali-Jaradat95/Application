using System;

namespace Application.SeverityLookups
{
    public abstract class SeverityLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}