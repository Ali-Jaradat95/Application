using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.ApiRequestResponseLogs
{
    public partial interface IApiRequestResponseLogRepository : IRepository<ApiRequestResponseLog, int>
    {
        Task<List<ApiRequestResponseLog>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}