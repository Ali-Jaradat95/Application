using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public partial interface IOrangeBillPaymentNotificationConfigurationRepository : IRepository<OrangeBillPaymentNotificationConfiguration, int>
    {
        Task<List<OrangeBillPaymentNotificationConfiguration>> GetListAsync(
            string? filterText = null,
            string? serviceTypeName = null,
            string? configurationKey = null,
            string? configurationValue = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? serviceTypeName = null,
            string? configurationKey = null,
            string? configurationValue = null,
            CancellationToken cancellationToken = default);
    }
}