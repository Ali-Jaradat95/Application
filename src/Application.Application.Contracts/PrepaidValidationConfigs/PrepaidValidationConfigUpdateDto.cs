using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Application.PrepaidValidationConfigs
{
    public abstract class PrepaidValidationConfigUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string ServiceType { get; set; } = null!;
        public string? ChannelCode { get; set; }
        public string? BillingName { get; set; }
        public string? AliasBillingName { get; set; }
        public bool IsTesting { get; set; }
        public string? EndpointUrl { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}