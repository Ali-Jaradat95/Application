using System;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationExcelDtoBase
    {
        public string ServiceTypeName { get; set; } = null!;
        public string ConfigurationKey { get; set; } = null!;
        public string ConfigurationValue { get; set; } = null!;
    }
}