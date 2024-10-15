using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Application.PaymentTypeLookups
{
    public abstract class PaymentTypeLookupUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}