using Volo.Abp.Application.Dtos;
using System;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class GetOrangeBillPaymentNotificationConfigurationsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? ServiceTypeName { get; set; }
        public string? ConfigurationKey { get; set; }
        public string? ConfigurationValue { get; set; }

        public GetOrangeBillPaymentNotificationConfigurationsInputBase()
        {

        }
    }
}