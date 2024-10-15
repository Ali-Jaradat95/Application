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

namespace Application.OrangeBillPullServiceConfigurations
{
    public abstract class EfCoreOrangeBillPullServiceConfigurationRepositoryBase : EfCoreRepository<ApplicationDbContext, OrangeBillPullServiceConfiguration, int>, IOrangeBillPullServiceConfigurationRepository
    {
        public EfCoreOrangeBillPullServiceConfigurationRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<OrangeBillPullServiceConfiguration>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, serviceTypeIdMin, serviceTypeIdMax, isServiceEnabled, isWebServiceEnabled, webServiceUrl, storedProcedureName, billerCode, connectionStringUserId, connectionStringPassword, connectionStringDataSource, logLevel, severityIdMin, severityIdMax, dailyLimitMin, dailyLimitMax, weeklyLimitMin, weeklyLimitMax, monthlyLimitMin, monthlyLimitMax, yearlyLimitMin, yearlyLimitMax, errorMessage);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? OrangeBillPullServiceConfigurationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, serviceTypeIdMin, serviceTypeIdMax, isServiceEnabled, isWebServiceEnabled, webServiceUrl, storedProcedureName, billerCode, connectionStringUserId, connectionStringPassword, connectionStringDataSource, logLevel, severityIdMin, severityIdMax, dailyLimitMin, dailyLimitMax, weeklyLimitMin, weeklyLimitMax, monthlyLimitMin, monthlyLimitMax, yearlyLimitMin, yearlyLimitMax, errorMessage);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<OrangeBillPullServiceConfiguration> ApplyFilter(
            IQueryable<OrangeBillPullServiceConfiguration> query,
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
            string? errorMessage = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.WebServiceUrl!.Contains(filterText!) || e.StoredProcedureName!.Contains(filterText!) || e.BillerCode!.Contains(filterText!) || e.ConnectionStringUserId!.Contains(filterText!) || e.ConnectionStringPassword!.Contains(filterText!) || e.ConnectionStringDataSource!.Contains(filterText!) || e.LogLevel!.Contains(filterText!) || e.ErrorMessage!.Contains(filterText!))
                    .WhereIf(serviceTypeIdMin.HasValue, e => e.ServiceTypeId >= serviceTypeIdMin!.Value)
                    .WhereIf(serviceTypeIdMax.HasValue, e => e.ServiceTypeId <= serviceTypeIdMax!.Value)
                    .WhereIf(isServiceEnabled.HasValue, e => e.IsServiceEnabled == isServiceEnabled)
                    .WhereIf(isWebServiceEnabled.HasValue, e => e.IsWebServiceEnabled == isWebServiceEnabled)
                    .WhereIf(!string.IsNullOrWhiteSpace(webServiceUrl), e => e.WebServiceUrl.Contains(webServiceUrl))
                    .WhereIf(!string.IsNullOrWhiteSpace(storedProcedureName), e => e.StoredProcedureName.Contains(storedProcedureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(billerCode), e => e.BillerCode.Contains(billerCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(connectionStringUserId), e => e.ConnectionStringUserId.Contains(connectionStringUserId))
                    .WhereIf(!string.IsNullOrWhiteSpace(connectionStringPassword), e => e.ConnectionStringPassword.Contains(connectionStringPassword))
                    .WhereIf(!string.IsNullOrWhiteSpace(connectionStringDataSource), e => e.ConnectionStringDataSource.Contains(connectionStringDataSource))
                    .WhereIf(!string.IsNullOrWhiteSpace(logLevel), e => e.LogLevel.Contains(logLevel))
                    .WhereIf(severityIdMin.HasValue, e => e.SeverityId >= severityIdMin!.Value)
                    .WhereIf(severityIdMax.HasValue, e => e.SeverityId <= severityIdMax!.Value)
                    .WhereIf(dailyLimitMin.HasValue, e => e.DailyLimit >= dailyLimitMin!.Value)
                    .WhereIf(dailyLimitMax.HasValue, e => e.DailyLimit <= dailyLimitMax!.Value)
                    .WhereIf(weeklyLimitMin.HasValue, e => e.WeeklyLimit >= weeklyLimitMin!.Value)
                    .WhereIf(weeklyLimitMax.HasValue, e => e.WeeklyLimit <= weeklyLimitMax!.Value)
                    .WhereIf(monthlyLimitMin.HasValue, e => e.MonthlyLimit >= monthlyLimitMin!.Value)
                    .WhereIf(monthlyLimitMax.HasValue, e => e.MonthlyLimit <= monthlyLimitMax!.Value)
                    .WhereIf(yearlyLimitMin.HasValue, e => e.YearlyLimit >= yearlyLimitMin!.Value)
                    .WhereIf(yearlyLimitMax.HasValue, e => e.YearlyLimit <= yearlyLimitMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(errorMessage), e => e.ErrorMessage.Contains(errorMessage));
        }
    }
}