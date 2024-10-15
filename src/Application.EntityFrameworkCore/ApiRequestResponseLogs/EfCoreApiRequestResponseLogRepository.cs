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

namespace Application.ApiRequestResponseLogs
{
    public abstract class EfCoreApiRequestResponseLogRepositoryBase : EfCoreRepository<ApplicationDbContext, ApiRequestResponseLog, int>, IApiRequestResponseLogRepository
    {
        public EfCoreApiRequestResponseLogRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ApiRequestResponseLog>> GetListAsync(
            string? filterText = null,
            string? requestUrl = null,
            string? requestMethod = null,
            string? requestHeaders = null,
            string? requestBody = null,
            string? responseBody = null,
            int? responseStatusCodeMin = null,
            int? responseStatusCodeMax = null,
            string? responseHeaders = null,
            int? durationMsMin = null,
            int? durationMsMax = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            string? correlationId = null,
            string? ipAddress = null,
            string? userId = null,
            string? errorDetails = null,
            bool? isSuccessful = null,
            string? sourceSystem = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, requestUrl, requestMethod, requestHeaders, requestBody, responseBody, responseStatusCodeMin, responseStatusCodeMax, responseHeaders, durationMsMin, durationMsMax, createdAtMin, createdAtMax, correlationId, ipAddress, userId, errorDetails, isSuccessful, sourceSystem);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ApiRequestResponseLogConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? requestUrl = null,
            string? requestMethod = null,
            string? requestHeaders = null,
            string? requestBody = null,
            string? responseBody = null,
            int? responseStatusCodeMin = null,
            int? responseStatusCodeMax = null,
            string? responseHeaders = null,
            int? durationMsMin = null,
            int? durationMsMax = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            string? correlationId = null,
            string? ipAddress = null,
            string? userId = null,
            string? errorDetails = null,
            bool? isSuccessful = null,
            string? sourceSystem = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, requestUrl, requestMethod, requestHeaders, requestBody, responseBody, responseStatusCodeMin, responseStatusCodeMax, responseHeaders, durationMsMin, durationMsMax, createdAtMin, createdAtMax, correlationId, ipAddress, userId, errorDetails, isSuccessful, sourceSystem);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ApiRequestResponseLog> ApplyFilter(
            IQueryable<ApiRequestResponseLog> query,
            string? filterText = null,
            string? requestUrl = null,
            string? requestMethod = null,
            string? requestHeaders = null,
            string? requestBody = null,
            string? responseBody = null,
            int? responseStatusCodeMin = null,
            int? responseStatusCodeMax = null,
            string? responseHeaders = null,
            int? durationMsMin = null,
            int? durationMsMax = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            string? correlationId = null,
            string? ipAddress = null,
            string? userId = null,
            string? errorDetails = null,
            bool? isSuccessful = null,
            string? sourceSystem = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.RequestUrl!.Contains(filterText!) || e.RequestMethod!.Contains(filterText!) || e.RequestHeaders!.Contains(filterText!) || e.RequestBody!.Contains(filterText!) || e.ResponseBody!.Contains(filterText!) || e.ResponseHeaders!.Contains(filterText!) || e.CorrelationId!.Contains(filterText!) || e.IpAddress!.Contains(filterText!) || e.UserId!.Contains(filterText!) || e.ErrorDetails!.Contains(filterText!) || e.SourceSystem!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(requestUrl), e => e.RequestUrl.Contains(requestUrl))
                    .WhereIf(!string.IsNullOrWhiteSpace(requestMethod), e => e.RequestMethod.Contains(requestMethod))
                    .WhereIf(!string.IsNullOrWhiteSpace(requestHeaders), e => e.RequestHeaders.Contains(requestHeaders))
                    .WhereIf(!string.IsNullOrWhiteSpace(requestBody), e => e.RequestBody.Contains(requestBody))
                    .WhereIf(!string.IsNullOrWhiteSpace(responseBody), e => e.ResponseBody.Contains(responseBody))
                    .WhereIf(responseStatusCodeMin.HasValue, e => e.ResponseStatusCode >= responseStatusCodeMin!.Value)
                    .WhereIf(responseStatusCodeMax.HasValue, e => e.ResponseStatusCode <= responseStatusCodeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(responseHeaders), e => e.ResponseHeaders.Contains(responseHeaders))
                    .WhereIf(durationMsMin.HasValue, e => e.DurationMs >= durationMsMin!.Value)
                    .WhereIf(durationMsMax.HasValue, e => e.DurationMs <= durationMsMax!.Value)
                    .WhereIf(createdAtMin.HasValue, e => e.CreatedAt >= createdAtMin!.Value)
                    .WhereIf(createdAtMax.HasValue, e => e.CreatedAt <= createdAtMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(correlationId), e => e.CorrelationId.Contains(correlationId))
                    .WhereIf(!string.IsNullOrWhiteSpace(ipAddress), e => e.IpAddress.Contains(ipAddress))
                    .WhereIf(!string.IsNullOrWhiteSpace(userId), e => e.UserId.Contains(userId))
                    .WhereIf(!string.IsNullOrWhiteSpace(errorDetails), e => e.ErrorDetails.Contains(errorDetails))
                    .WhereIf(isSuccessful.HasValue, e => e.IsSuccessful == isSuccessful)
                    .WhereIf(!string.IsNullOrWhiteSpace(sourceSystem), e => e.SourceSystem.Contains(sourceSystem));
        }
    }
}