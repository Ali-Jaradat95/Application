using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.PaymentMethodLookups
{
    public abstract class PaymentMethodLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}