using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.OrangeBillPullServiceConfigurations
{
    public abstract class OrangeBillPullServiceConfigurationManagerBase : DomainService
    {
        protected IOrangeBillPullServiceConfigurationRepository _orangeBillPullServiceConfigurationRepository;

        public OrangeBillPullServiceConfigurationManagerBase(IOrangeBillPullServiceConfigurationRepository orangeBillPullServiceConfigurationRepository)
        {
            _orangeBillPullServiceConfigurationRepository = orangeBillPullServiceConfigurationRepository;
        }

        public virtual async Task<OrangeBillPullServiceConfiguration> CreateAsync(
        int serviceTypeId, bool isServiceEnabled, bool isWebServiceEnabled, string webServiceUrl, string? storedProcedureName = null, string? billerCode = null, string? connectionStringUserId = null, string? connectionStringPassword = null, string? connectionStringDataSource = null, string? logLevel = null, int? severityId = null, int? dailyLimit = null, int? weeklyLimit = null, int? monthlyLimit = null, int? yearlyLimit = null, string? errorMessage = null)
        {
            Check.NotNullOrWhiteSpace(webServiceUrl, nameof(webServiceUrl));

            var orangeBillPullServiceConfiguration = new OrangeBillPullServiceConfiguration(

             serviceTypeId, isServiceEnabled, isWebServiceEnabled, webServiceUrl, storedProcedureName, billerCode, connectionStringUserId, connectionStringPassword, connectionStringDataSource, logLevel, severityId, dailyLimit, weeklyLimit, monthlyLimit, yearlyLimit, errorMessage
             );

            return await _orangeBillPullServiceConfigurationRepository.InsertAsync(orangeBillPullServiceConfiguration);
        }

        public virtual async Task<OrangeBillPullServiceConfiguration> UpdateAsync(
            int id,
            int serviceTypeId, bool isServiceEnabled, bool isWebServiceEnabled, string webServiceUrl, string? storedProcedureName = null, string? billerCode = null, string? connectionStringUserId = null, string? connectionStringPassword = null, string? connectionStringDataSource = null, string? logLevel = null, int? severityId = null, int? dailyLimit = null, int? weeklyLimit = null, int? monthlyLimit = null, int? yearlyLimit = null, string? errorMessage = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(webServiceUrl, nameof(webServiceUrl));

            var orangeBillPullServiceConfiguration = await _orangeBillPullServiceConfigurationRepository.GetAsync(id);

            orangeBillPullServiceConfiguration.ServiceTypeId = serviceTypeId;
            orangeBillPullServiceConfiguration.IsServiceEnabled = isServiceEnabled;
            orangeBillPullServiceConfiguration.IsWebServiceEnabled = isWebServiceEnabled;
            orangeBillPullServiceConfiguration.WebServiceUrl = webServiceUrl;
            orangeBillPullServiceConfiguration.StoredProcedureName = storedProcedureName;
            orangeBillPullServiceConfiguration.BillerCode = billerCode;
            orangeBillPullServiceConfiguration.ConnectionStringUserId = connectionStringUserId;
            orangeBillPullServiceConfiguration.ConnectionStringPassword = connectionStringPassword;
            orangeBillPullServiceConfiguration.ConnectionStringDataSource = connectionStringDataSource;
            orangeBillPullServiceConfiguration.LogLevel = logLevel;
            orangeBillPullServiceConfiguration.SeverityId = severityId;
            orangeBillPullServiceConfiguration.DailyLimit = dailyLimit;
            orangeBillPullServiceConfiguration.WeeklyLimit = weeklyLimit;
            orangeBillPullServiceConfiguration.MonthlyLimit = monthlyLimit;
            orangeBillPullServiceConfiguration.YearlyLimit = yearlyLimit;
            orangeBillPullServiceConfiguration.ErrorMessage = errorMessage;

            orangeBillPullServiceConfiguration.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _orangeBillPullServiceConfigurationRepository.UpdateAsync(orangeBillPullServiceConfiguration);
        }

    }
}