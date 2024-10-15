using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationCreateDtoBase
    {
        [Required]
        public string ServiceTypeName { get; set; } = null!;
        [Required]
        public string ConfigurationKey { get; set; } = null!;
        [Required]
        public string ConfigurationValue { get; set; } = null!;
    }
}