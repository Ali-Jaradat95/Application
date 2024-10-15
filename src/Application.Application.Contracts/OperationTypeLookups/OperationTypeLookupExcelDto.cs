using System;

namespace Application.OperationTypeLookups
{
    public abstract class OperationTypeLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}