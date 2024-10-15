using Volo.Abp.Application.Dtos;
using System;

namespace Application.PrepaidValidationConfigs
{
    public abstract class PrepaidValidationConfigExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? ServiceType { get; set; }
        public string? ChannelCode { get; set; }
        public string? BillingName { get; set; }
        public string? AliasBillingName { get; set; }
        public bool? IsTesting { get; set; }
        public string? EndpointUrl { get; set; }

        public PrepaidValidationConfigExcelDownloadDtoBase()
        {

        }
    }
}