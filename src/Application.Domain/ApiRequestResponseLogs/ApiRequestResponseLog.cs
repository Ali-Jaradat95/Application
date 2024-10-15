using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.ApiRequestResponseLogs
{
    public abstract class ApiRequestResponseLogBase : FullAuditedAggregateRoot<int>
    {
        [CanBeNull]
        public virtual string? RequestUrl { get; set; }

        [CanBeNull]
        public virtual string? RequestMethod { get; set; }

        [CanBeNull]
        public virtual string? RequestHeaders { get; set; }

        [CanBeNull]
        public virtual string? RequestBody { get; set; }

        [CanBeNull]
        public virtual string? ResponseBody { get; set; }

        public virtual int? ResponseStatusCode { get; set; }

        [CanBeNull]
        public virtual string? ResponseHeaders { get; set; }

        public virtual int? DurationMs { get; set; }

        public virtual DateTime? CreatedAt { get; set; }

        [CanBeNull]
        public virtual string? CorrelationId { get; set; }

        [CanBeNull]
        public virtual string? IpAddress { get; set; }

        [CanBeNull]
        public virtual string? UserId { get; set; }

        [CanBeNull]
        public virtual string? ErrorDetails { get; set; }

        public virtual bool IsSuccessful { get; set; }

        [CanBeNull]
        public virtual string? SourceSystem { get; set; }

        protected ApiRequestResponseLogBase()
        {

        }

        public ApiRequestResponseLogBase(bool isSuccessful, string? requestUrl = null, string? requestMethod = null, string? requestHeaders = null, string? requestBody = null, string? responseBody = null, int? responseStatusCode = null, string? responseHeaders = null, int? durationMs = null, DateTime? createdAt = null, string? correlationId = null, string? ipAddress = null, string? userId = null, string? errorDetails = null, string? sourceSystem = null)
        {

            IsSuccessful = isSuccessful;
            RequestUrl = requestUrl;
            RequestMethod = requestMethod;
            RequestHeaders = requestHeaders;
            RequestBody = requestBody;
            ResponseBody = responseBody;
            ResponseStatusCode = responseStatusCode;
            ResponseHeaders = responseHeaders;
            DurationMs = durationMs;
            CreatedAt = createdAt;
            CorrelationId = correlationId;
            IpAddress = ipAddress;
            UserId = userId;
            ErrorDetails = errorDetails;
            SourceSystem = sourceSystem;
        }

    }
}