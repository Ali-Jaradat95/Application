using System;

namespace Application.BillTypeLookups
{
    public abstract class BillTypeLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}