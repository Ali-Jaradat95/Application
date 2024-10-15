using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.PrepaidValidationConfigs
{
    public abstract class PrepaidValidationConfigBase : FullAuditedAggregateRoot<int>
    {
        [NotNull]
        public virtual string ServiceType { get; set; }

        [CanBeNull]
        public virtual string? ChannelCode { get; set; }

        [CanBeNull]
        public virtual string? BillingName { get; set; }

        [CanBeNull]
        public virtual string? AliasBillingName { get; set; }

        public virtual bool IsTesting { get; set; }

        [CanBeNull]
        public virtual string? EndpointUrl { get; set; }

        protected PrepaidValidationConfigBase()
        {

        }

        public PrepaidValidationConfigBase(string serviceType, bool isTesting, string? channelCode = null, string? billingName = null, string? aliasBillingName = null, string? endpointUrl = null)
        {

            Check.NotNull(serviceType, nameof(serviceType));
            ServiceType = serviceType;
            IsTesting = isTesting;
            ChannelCode = channelCode;
            BillingName = billingName;
            AliasBillingName = aliasBillingName;
            EndpointUrl = endpointUrl;
        }

    }
}