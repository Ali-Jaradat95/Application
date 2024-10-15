using System;

namespace Application.PrepaidValidationConfigs
{
    public abstract class PrepaidValidationConfigExcelDtoBase
    {
        public string ServiceType { get; set; } = null!;
        public string? ChannelCode { get; set; }
        public string? BillingName { get; set; }
        public string? AliasBillingName { get; set; }
        public bool IsTesting { get; set; }
        public string? EndpointUrl { get; set; }
    }
}