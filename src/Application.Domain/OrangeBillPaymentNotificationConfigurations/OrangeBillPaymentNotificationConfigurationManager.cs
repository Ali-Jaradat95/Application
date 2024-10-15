using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class OrangeBillPaymentNotificationConfigurationManagerBase : DomainService
    {
        protected IOrangeBillPaymentNotificationConfigurationRepository _orangeBillPaymentNotificationConfigurationRepository;

        public OrangeBillPaymentNotificationConfigurationManagerBase(IOrangeBillPaymentNotificationConfigurationRepository orangeBillPaymentNotificationConfigurationRepository)
        {
            _orangeBillPaymentNotificationConfigurationRepository = orangeBillPaymentNotificationConfigurationRepository;
        }

        public virtual async Task<OrangeBillPaymentNotificationConfiguration> CreateAsync(
        string serviceTypeName, string configurationKey, string configurationValue)
        {
            Check.NotNullOrWhiteSpace(serviceTypeName, nameof(serviceTypeName));
            Check.NotNullOrWhiteSpace(configurationKey, nameof(configurationKey));
            Check.NotNullOrWhiteSpace(configurationValue, nameof(configurationValue));

            var orangeBillPaymentNotificationConfiguration = new OrangeBillPaymentNotificationConfiguration(

             serviceTypeName, configurationKey, configurationValue
             );

            return await _orangeBillPaymentNotificationConfigurationRepository.InsertAsync(orangeBillPaymentNotificationConfiguration);
        }

        public virtual async Task<OrangeBillPaymentNotificationConfiguration> UpdateAsync(
            int id,
            string serviceTypeName, string configurationKey, string configurationValue, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(serviceTypeName, nameof(serviceTypeName));
            Check.NotNullOrWhiteSpace(configurationKey, nameof(configurationKey));
            Check.NotNullOrWhiteSpace(configurationValue, nameof(configurationValue));

            var orangeBillPaymentNotificationConfiguration = await _orangeBillPaymentNotificationConfigurationRepository.GetAsync(id);

            orangeBillPaymentNotificationConfiguration.ServiceTypeName = serviceTypeName;
            orangeBillPaymentNotificationConfiguration.ConfigurationKey = configurationKey;
            orangeBillPaymentNotificationConfiguration.ConfigurationValue = configurationValue;

            orangeBillPaymentNotificationConfiguration.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _orangeBillPaymentNotificationConfigurationRepository.UpdateAsync(orangeBillPaymentNotificationConfiguration);
        }

    }
}