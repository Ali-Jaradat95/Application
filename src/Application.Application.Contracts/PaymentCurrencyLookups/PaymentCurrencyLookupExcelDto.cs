using System;

namespace Application.PaymentCurrencyLookups
{
    public abstract class PaymentCurrencyLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}