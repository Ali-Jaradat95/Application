using System;

namespace Application.MethodTypeLookups
{
    public abstract class MethodTypeLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}