using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.OrangeBillPullServiceConfigurations
{
    public partial interface IOrangeBillPullServiceConfigurationRepository : IRepository<OrangeBillPullServiceConfiguration, int>
    {
        Task<List<OrangeBillPullServiceConfiguration>> GetListAsync(
            string? filterText = null,
            int? serviceTypeIdMin = null,
            int? serviceTypeIdMax = null,
            bool? isServiceEnabled = null,
            bool? isWebServiceEnabled = null,
            string? webServiceUrl = null,
            string? storedProcedureName = null,
            string? billerCode = null,
            string? connectionStringUserId = null,
            string? connectionStringPassword = null,
            string? connectionStringDataSource = null,
            string? logLevel = null,
            int? severityIdMin = null,
            int? severityIdMax = null,
            int? dailyLimitMin = null,
            int? dailyLimitMax = null,
            int? weeklyLimitMin = null,
            int? weeklyLimitMax = null,
            int? monthlyLimitMin = null,
            int? monthlyLimitMax = null,
            int? yearlyLimitMin = null,
            int? yearlyLimitMax = null,
            string? errorMessage = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? serviceTypeIdMin = null,
            int? serviceTypeIdMax = null,
            bool? isServiceEnabled = null,
            bool? isWebServiceEnabled = null,
            string? webServiceUrl = null,
            string? storedProcedureName = null,
            string? billerCode = null,
            string? connectionStringUserId = null,
            string? connectionStringPassword = null,
            string? connectionStringDataSource = null,
            string? logLevel = null,
            int? severityIdMin = null,
            int? severityIdMax = null,
            int? dailyLimitMin = null,
            int? dailyLimitMax = null,
            int? weeklyLimitMin = null,
            int? weeklyLimitMax = null,
            int? monthlyLimitMin = null,
            int? monthlyLimitMax = null,
            int? yearlyLimitMin = null,
            int? yearlyLimitMax = null,
            string? errorMessage = null,
            CancellationToken cancellationToken = default);
    }
}