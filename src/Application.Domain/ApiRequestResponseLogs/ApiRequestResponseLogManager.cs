using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.ApiRequestResponseLogs
{
    public abstract class ApiRequestResponseLogManagerBase : DomainService
    {
        protected IApiRequestResponseLogRepository _apiRequestResponseLogRepository;

        public ApiRequestResponseLogManagerBase(IApiRequestResponseLogRepository apiRequestResponseLogRepository)
        {
            _apiRequestResponseLogRepository = apiRequestResponseLogRepository;
        }

        public virtual async Task<ApiRequestResponseLog> CreateAsync(
        bool isSuccessful, string? requestUrl = null, string? requestMethod = null, string? requestHeaders = null, string? requestBody = null, string? responseBody = null, int? responseStatusCode = null, string? responseHeaders = null, int? durationMs = null, DateTime? createdAt = null, string? correlationId = null, string? ipAddress = null, string? userId = null, string? errorDetails = null, string? sourceSystem = null)
        {

            var apiRequestResponseLog = new ApiRequestResponseLog(

             isSuccessful, requestUrl, requestMethod, requestHeaders, requestBody, responseBody, responseStatusCode, responseHeaders, durationMs, createdAt, correlationId, ipAddress, userId, errorDetails, sourceSystem
             );

            return await _apiRequestResponseLogRepository.InsertAsync(apiRequestResponseLog);
        }

        public virtual async Task<ApiRequestResponseLog> UpdateAsync(
            int id,
            bool isSuccessful, string? requestUrl = null, string? requestMethod = null, string? requestHeaders = null, string? requestBody = null, string? responseBody = null, int? responseStatusCode = null, string? responseHeaders = null, int? durationMs = null, DateTime? createdAt = null, string? correlationId = null, string? ipAddress = null, string? userId = null, string? errorDetails = null, string? sourceSystem = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var apiRequestResponseLog = await _apiRequestResponseLogRepository.GetAsync(id);

            apiRequestResponseLog.IsSuccessful = isSuccessful;
            apiRequestResponseLog.RequestUrl = requestUrl;
            apiRequestResponseLog.RequestMethod = requestMethod;
            apiRequestResponseLog.RequestHeaders = requestHeaders;
            apiRequestResponseLog.RequestBody = requestBody;
            apiRequestResponseLog.ResponseBody = responseBody;
            apiRequestResponseLog.ResponseStatusCode = responseStatusCode;
            apiRequestResponseLog.ResponseHeaders = responseHeaders;
            apiRequestResponseLog.DurationMs = durationMs;
            apiRequestResponseLog.CreatedAt = createdAt;
            apiRequestResponseLog.CorrelationId = correlationId;
            apiRequestResponseLog.IpAddress = ipAddress;
            apiRequestResponseLog.UserId = userId;
            apiRequestResponseLog.ErrorDetails = errorDetails;
            apiRequestResponseLog.SourceSystem = sourceSystem;

            apiRequestResponseLog.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _apiRequestResponseLogRepository.UpdateAsync(apiRequestResponseLog);
        }

    }
}