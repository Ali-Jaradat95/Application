using System;

namespace Application.PaymentStatusLookups
{
    public abstract class PaymentStatusLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}