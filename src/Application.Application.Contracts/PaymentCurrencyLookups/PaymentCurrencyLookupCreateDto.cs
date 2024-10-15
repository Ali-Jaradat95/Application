using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.PaymentCurrencyLookups
{
    public abstract class PaymentCurrencyLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}