using System;

namespace Application.LanguageIsoNameLookups
{
    public abstract class LanguageIsoNameLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}