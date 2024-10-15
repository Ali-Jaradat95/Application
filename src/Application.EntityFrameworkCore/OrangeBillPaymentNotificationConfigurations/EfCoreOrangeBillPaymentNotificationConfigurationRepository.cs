using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Application.EntityFrameworkCore;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public abstract class EfCoreOrangeBillPaymentNotificationConfigurationRepositoryBase : EfCoreRepository<ApplicationDbContext, OrangeBillPaymentNotificationConfiguration, int>, IOrangeBillPaymentNotificationConfigurationRepository
    {
        public EfCoreOrangeBillPaymentNotificationConfigurationRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<OrangeBillPaymentNotificationConfiguration>> GetListAsync(
            string? filterText = null,
            string? serviceTypeName = null,
            string? configurationKey = null,
            string? configurationValue = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, serviceTypeName, configurationKey, configurationValue);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? OrangeBillPaymentNotificationConfigurationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? serviceTypeName = null,
            string? configurationKey = null,
            string? configurationValue = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, serviceTypeName, configurationKey, configurationValue);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<OrangeBillPaymentNotificationConfiguration> ApplyFilter(
            IQueryable<OrangeBillPaymentNotificationConfiguration> query,
            string? filterText = null,
            string? serviceTypeName = null,
            string? configurationKey = null,
            string? configurationValue = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ServiceTypeName!.Contains(filterText!) || e.ConfigurationKey!.Contains(filterText!) || e.ConfigurationValue!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceTypeName), e => e.ServiceTypeName.Contains(serviceTypeName))
                    .WhereIf(!string.IsNullOrWhiteSpace(configurationKey), e => e.ConfigurationKey.Contains(configurationKey))
                    .WhereIf(!string.IsNullOrWhiteSpace(configurationValue), e => e.ConfigurationValue.Contains(configurationValue));
        }
    }
}