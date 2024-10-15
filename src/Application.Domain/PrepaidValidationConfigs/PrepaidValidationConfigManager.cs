using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PrepaidValidationConfigs
{
    public abstract class PrepaidValidationConfigManagerBase : DomainService
    {
        protected IPrepaidValidationConfigRepository _prepaidValidationConfigRepository;

        public PrepaidValidationConfigManagerBase(IPrepaidValidationConfigRepository prepaidValidationConfigRepository)
        {
            _prepaidValidationConfigRepository = prepaidValidationConfigRepository;
        }

        public virtual async Task<PrepaidValidationConfig> CreateAsync(
        string serviceType, bool isTesting, string? channelCode = null, string? billingName = null, string? aliasBillingName = null, string? endpointUrl = null)
        {
            Check.NotNullOrWhiteSpace(serviceType, nameof(serviceType));

            var prepaidValidationConfig = new PrepaidValidationConfig(

             serviceType, isTesting, channelCode, billingName, aliasBillingName, endpointUrl
             );

            return await _prepaidValidationConfigRepository.InsertAsync(prepaidValidationConfig);
        }

        public virtual async Task<PrepaidValidationConfig> UpdateAsync(
            int id,
            string serviceType, bool isTesting, string? channelCode = null, string? billingName = null, string? aliasBillingName = null, string? endpointUrl = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(serviceType, nameof(serviceType));

            var prepaidValidationConfig = await _prepaidValidationConfigRepository.GetAsync(id);

            prepaidValidationConfig.ServiceType = serviceType;
            prepaidValidationConfig.IsTesting = isTesting;
            prepaidValidationConfig.ChannelCode = channelCode;
            prepaidValidationConfig.BillingName = billingName;
            prepaidValidationConfig.AliasBillingName = aliasBillingName;
            prepaidValidationConfig.EndpointUrl = endpointUrl;

            prepaidValidationConfig.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _prepaidValidationConfigRepository.UpdateAsync(prepaidValidationConfig);
        }

    }
}