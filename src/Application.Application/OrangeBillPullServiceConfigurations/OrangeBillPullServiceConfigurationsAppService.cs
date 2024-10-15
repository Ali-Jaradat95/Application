using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Application.Permissions;
using Application.OrangeBillPullServiceConfigurations;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.OrangeBillPullServiceConfigurations
{

    [Authorize(ApplicationPermissions.OrangeBillPullServiceConfigurations.Default)]
    public abstract class OrangeBillPullServiceConfigurationsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<OrangeBillPullServiceConfigurationExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IOrangeBillPullServiceConfigurationRepository _orangeBillPullServiceConfigurationRepository;
        protected OrangeBillPullServiceConfigurationManager _orangeBillPullServiceConfigurationManager;

        public OrangeBillPullServiceConfigurationsAppServiceBase(IOrangeBillPullServiceConfigurationRepository orangeBillPullServiceConfigurationRepository, OrangeBillPullServiceConfigurationManager orangeBillPullServiceConfigurationManager, IDistributedCache<OrangeBillPullServiceConfigurationExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _orangeBillPullServiceConfigurationRepository = orangeBillPullServiceConfigurationRepository;
            _orangeBillPullServiceConfigurationManager = orangeBillPullServiceConfigurationManager;
        }

        public virtual async Task<PagedResultDto<OrangeBillPullServiceConfigurationDto>> GetListAsync(GetOrangeBillPullServiceConfigurationsInput input)
        {
            var totalCount = await _orangeBillPullServiceConfigurationRepository.GetCountAsync(input.FilterText, input.ServiceTypeIdMin, input.ServiceTypeIdMax, input.IsServiceEnabled, input.IsWebServiceEnabled, input.WebServiceUrl, input.StoredProcedureName, input.BillerCode, input.ConnectionStringUserId, input.ConnectionStringPassword, input.ConnectionStringDataSource, input.LogLevel, input.SeverityIdMin, input.SeverityIdMax, input.DailyLimitMin, input.DailyLimitMax, input.WeeklyLimitMin, input.WeeklyLimitMax, input.MonthlyLimitMin, input.MonthlyLimitMax, input.YearlyLimitMin, input.YearlyLimitMax, input.ErrorMessage);
            var items = await _orangeBillPullServiceConfigurationRepository.GetListAsync(input.FilterText, input.ServiceTypeIdMin, input.ServiceTypeIdMax, input.IsServiceEnabled, input.IsWebServiceEnabled, input.WebServiceUrl, input.StoredProcedureName, input.BillerCode, input.ConnectionStringUserId, input.ConnectionStringPassword, input.ConnectionStringDataSource, input.LogLevel, input.SeverityIdMin, input.SeverityIdMax, input.DailyLimitMin, input.DailyLimitMax, input.WeeklyLimitMin, input.WeeklyLimitMax, input.MonthlyLimitMin, input.MonthlyLimitMax, input.YearlyLimitMin, input.YearlyLimitMax, input.ErrorMessage, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<OrangeBillPullServiceConfigurationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<OrangeBillPullServiceConfiguration>, List<OrangeBillPullServiceConfigurationDto>>(items)
            };
        }

        public virtual async Task<OrangeBillPullServiceConfigurationDto> GetAsync(int id)
        {
            return ObjectMapper.Map<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurationDto>(await _orangeBillPullServiceConfigurationRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.OrangeBillPullServiceConfigurations.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _orangeBillPullServiceConfigurationRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.OrangeBillPullServiceConfigurations.Create)]
        public virtual async Task<OrangeBillPullServiceConfigurationDto> CreateAsync(OrangeBillPullServiceConfigurationCreateDto input)
        {

            var orangeBillPullServiceConfiguration = await _orangeBillPullServiceConfigurationManager.CreateAsync(
            input.ServiceTypeId, input.IsServiceEnabled, input.IsWebServiceEnabled, input.WebServiceUrl, input.StoredProcedureName, input.BillerCode, input.ConnectionStringUserId, input.ConnectionStringPassword, input.ConnectionStringDataSource, input.LogLevel, input.SeverityId, input.DailyLimit, input.WeeklyLimit, input.MonthlyLimit, input.YearlyLimit, input.ErrorMessage
            );

            return ObjectMapper.Map<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurationDto>(orangeBillPullServiceConfiguration);
        }

        [Authorize(ApplicationPermissions.OrangeBillPullServiceConfigurations.Edit)]
        public virtual async Task<OrangeBillPullServiceConfigurationDto> UpdateAsync(int id, OrangeBillPullServiceConfigurationUpdateDto input)
        {

            var orangeBillPullServiceConfiguration = await _orangeBillPullServiceConfigurationManager.UpdateAsync(
            id,
            input.ServiceTypeId, input.IsServiceEnabled, input.IsWebServiceEnabled, input.WebServiceUrl, input.StoredProcedureName, input.BillerCode, input.ConnectionStringUserId, input.ConnectionStringPassword, input.ConnectionStringDataSource, input.LogLevel, input.SeverityId, input.DailyLimit, input.WeeklyLimit, input.MonthlyLimit, input.YearlyLimit, input.ErrorMessage, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurationDto>(orangeBillPullServiceConfiguration);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(OrangeBillPullServiceConfigurationExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _orangeBillPullServiceConfigurationRepository.GetListAsync(input.FilterText, input.ServiceTypeIdMin, input.ServiceTypeIdMax, input.IsServiceEnabled, input.IsWebServiceEnabled, input.WebServiceUrl, input.StoredProcedureName, input.BillerCode, input.ConnectionStringUserId, input.ConnectionStringPassword, input.ConnectionStringDataSource, input.LogLevel, input.SeverityIdMin, input.SeverityIdMax, input.DailyLimitMin, input.DailyLimitMax, input.WeeklyLimitMin, input.WeeklyLimitMax, input.MonthlyLimitMin, input.MonthlyLimitMax, input.YearlyLimitMin, input.YearlyLimitMax, input.ErrorMessage);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<OrangeBillPullServiceConfiguration>, List<OrangeBillPullServiceConfigurationExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "OrangeBillPullServiceConfigurations.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new OrangeBillPullServiceConfigurationExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}