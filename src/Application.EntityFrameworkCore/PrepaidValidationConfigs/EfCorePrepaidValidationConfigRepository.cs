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

namespace Application.PrepaidValidationConfigs
{
    public abstract class EfCorePrepaidValidationConfigRepositoryBase : EfCoreRepository<ApplicationDbContext, PrepaidValidationConfig, int>, IPrepaidValidationConfigRepository
    {
        public EfCorePrepaidValidationConfigRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<PrepaidValidationConfig>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, serviceType, channelCode, billingName, aliasBillingName, isTesting, endpointUrl);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PrepaidValidationConfigConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? serviceType = null,
            string? channelCode = null,
            string? billingName = null,
            string? aliasBillingName = null,
            bool? isTesting = null,
            string? endpointUrl = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, serviceType, channelCode, billingName, aliasBillingName, isTesting, endpointUrl);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<PrepaidValidationConfig> ApplyFilter(
            IQueryable<PrepaidValidationConfig> query,
            string? filterText = null,
            string? serviceType = null,
            string? channelCode = null,
            string? billingName = null,
            string? aliasBillingName = null,
            bool? isTesting = null,
            string? endpointUrl = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ServiceType!.Contains(filterText!) || e.ChannelCode!.Contains(filterText!) || e.BillingName!.Contains(filterText!) || e.AliasBillingName!.Contains(filterText!) || e.EndpointUrl!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceType), e => e.ServiceType.Contains(serviceType))
                    .WhereIf(!string.IsNullOrWhiteSpace(channelCode), e => e.ChannelCode.Contains(channelCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(billingName), e => e.BillingName.Contains(billingName))
                    .WhereIf(!string.IsNullOrWhiteSpace(aliasBillingName), e => e.AliasBillingName.Contains(aliasBillingName))
                    .WhereIf(isTesting.HasValue, e => e.IsTesting == isTesting)
                    .WhereIf(!string.IsNullOrWhiteSpace(endpointUrl), e => e.EndpointUrl.Contains(endpointUrl));
        }
    }
}