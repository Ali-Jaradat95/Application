using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.PrepaidValidationConfigs
{
    public partial interface IPrepaidValidationConfigRepository : IRepository<PrepaidValidationConfig, int>
    {
        Task<List<PrepaidValidationConfig>> GetListAsync(
            string? filterText = null,
            string? serviceType = null,
            string? channelCode = null,
            string? billingName = null,
            string? aliasBillingName = null,
            bool? isTesting = null,
            string? endpointUrl = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? serviceType = null,
            string? channelCode = null,
            string? billingName = null,
            string? aliasBillingName = null,
            bool? isTesting = null,
            string? endpointUrl = null,
            CancellationToken cancellationToken = default);
    }
}