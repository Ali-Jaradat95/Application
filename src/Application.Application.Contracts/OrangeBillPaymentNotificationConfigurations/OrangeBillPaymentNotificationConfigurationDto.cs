using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string ServiceTypeName { get; set; } = null!;
        public string ConfigurationKey { get; set; } = null!;
        public string ConfigurationValue { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}