using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationBase : FullAuditedAggregateRoot<int>
    {
        [NotNull]
        public virtual string ServiceTypeName { get; set; }

        [NotNull]
        public virtual string ConfigurationKey { get; set; }

        [NotNull]
        public virtual string ConfigurationValue { get; set; }

        protected OrangeBillPaymentNotificationConfigurationBase()
        {

        }

        public OrangeBillPaymentNotificationConfigurationBase(string serviceTypeName, string configurationKey, string configurationValue)
        {

            Check.NotNull(serviceTypeName, nameof(serviceTypeName));
            Check.NotNull(configurationKey, nameof(configurationKey));
            Check.NotNull(configurationValue, nameof(configurationValue));
            ServiceTypeName = serviceTypeName;
            ConfigurationKey = configurationKey;
            ConfigurationValue = configurationValue;
        }

    }
}