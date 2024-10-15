using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string ServiceTypeName { get; set; } = null!;
        [Required]
        public string ConfigurationKey { get; set; } = null!;
        [Required]
        public string ConfigurationValue { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}