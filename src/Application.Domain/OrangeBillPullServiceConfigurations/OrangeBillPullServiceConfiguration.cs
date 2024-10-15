using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.OrangeBillPullServiceConfigurations
{
    public abstract class OrangeBillPullServiceConfigurationBase : FullAuditedAggregateRoot<int>
    {
        public virtual int ServiceTypeId { get; set; }

        public virtual bool IsServiceEnabled { get; set; }

        public virtual bool IsWebServiceEnabled { get; set; }

        [NotNull]
        public virtual string WebServiceUrl { get; set; }

        [CanBeNull]
        public virtual string? StoredProcedureName { get; set; }

        [CanBeNull]
        public virtual string? BillerCode { get; set; }

        [CanBeNull]
        public virtual string? ConnectionStringUserId { get; set; }

        [CanBeNull]
        public virtual string? ConnectionStringPassword { get; set; }

        [CanBeNull]
        public virtual string? ConnectionStringDataSource { get; set; }

        [CanBeNull]
        public virtual string? LogLevel { get; set; }

        public virtual int? SeverityId { get; set; }

        public virtual int? DailyLimit { get; set; }

        public virtual int? WeeklyLimit { get; set; }

        public virtual int? MonthlyLimit { get; set; }

        public virtual int? YearlyLimit { get; set; }

        [CanBeNull]
        public virtual string? ErrorMessage { get; set; }

        protected OrangeBillPullServiceConfigurationBase()
        {

        }

        public OrangeBillPullServiceConfigurationBase(int serviceTypeId, bool isServiceEnabled, bool isWebServiceEnabled, string webServiceUrl, string? storedProcedureName = null, string? billerCode = null, string? connectionStringUserId = null, string? connectionStringPassword = null, string? connectionStringDataSource = null, string? logLevel = null, int? severityId = null, int? dailyLimit = null, int? weeklyLimit = null, int? monthlyLimit = null, int? yearlyLimit = null, string? errorMessage = null)
        {

            Check.NotNull(webServiceUrl, nameof(webServiceUrl));
            ServiceTypeId = serviceTypeId;
            IsServiceEnabled = isServiceEnabled;
            IsWebServiceEnabled = isWebServiceEnabled;
            WebServiceUrl = webServiceUrl;
            StoredProcedureName = storedProcedureName;
            BillerCode = billerCode;
            ConnectionStringUserId = connectionStringUserId;
            ConnectionStringPassword = connectionStringPassword;
            ConnectionStringDataSource = connectionStringDataSource;
            LogLevel = logLevel;
            SeverityId = severityId;
            DailyLimit = dailyLimit;
            WeeklyLimit = weeklyLimit;
            MonthlyLimit = monthlyLimit;
            YearlyLimit = yearlyLimit;
            ErrorMessage = errorMessage;
        }

    }
}