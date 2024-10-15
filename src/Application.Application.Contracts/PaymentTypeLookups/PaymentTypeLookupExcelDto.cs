using System;

namespace Application.PaymentTypeLookups
{
    public abstract class PaymentTypeLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}