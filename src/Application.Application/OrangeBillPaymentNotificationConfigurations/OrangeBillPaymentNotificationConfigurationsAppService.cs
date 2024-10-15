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
using Application.OrangeBillPaymentNotificationConfigurations;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.OrangeBillPaymentNotificationConfigurations
{

    [Authorize(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Default)]
    public abstract class OrangeBillPaymentNotificationConfigurationsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<OrangeBillPaymentNotificationConfigurationExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IOrangeBillPaymentNotificationConfigurationRepository _orangeBillPaymentNotificationConfigurationRepository;
        protected OrangeBillPaymentNotificationConfigurationManager _orangeBillPaymentNotificationConfigurationManager;

        public OrangeBillPaymentNotificationConfigurationsAppServiceBase(IOrangeBillPaymentNotificationConfigurationRepository orangeBillPaymentNotificationConfigurationRepository, OrangeBillPaymentNotificationConfigurationManager orangeBillPaymentNotificationConfigurationManager, IDistributedCache<OrangeBillPaymentNotificationConfigurationExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _orangeBillPaymentNotificationConfigurationRepository = orangeBillPaymentNotificationConfigurationRepository;
            _orangeBillPaymentNotificationConfigurationManager = orangeBillPaymentNotificationConfigurationManager;
        }

        public virtual async Task<PagedResultDto<OrangeBillPaymentNotificationConfigurationDto>> GetListAsync(GetOrangeBillPaymentNotificationConfigurationsInput input)
        {
            var totalCount = await _orangeBillPaymentNotificationConfigurationRepository.GetCountAsync(input.FilterText, input.ServiceTypeName, input.ConfigurationKey, input.ConfigurationValue);
            var items = await _orangeBillPaymentNotificationConfigurationRepository.GetListAsync(input.FilterText, input.ServiceTypeName, input.ConfigurationKey, input.ConfigurationValue, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<OrangeBillPaymentNotificationConfigurationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<OrangeBillPaymentNotificationConfiguration>, List<OrangeBillPaymentNotificationConfigurationDto>>(items)
            };
        }

        public virtual async Task<OrangeBillPaymentNotificationConfigurationDto> GetAsync(int id)
        {
            return ObjectMapper.Map<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurationDto>(await _orangeBillPaymentNotificationConfigurationRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _orangeBillPaymentNotificationConfigurationRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Create)]
        public virtual async Task<OrangeBillPaymentNotificationConfigurationDto> CreateAsync(OrangeBillPaymentNotificationConfigurationCreateDto input)
        {

            var orangeBillPaymentNotificationConfiguration = await _orangeBillPaymentNotificationConfigurationManager.CreateAsync(
            input.ServiceTypeName, input.ConfigurationKey, input.ConfigurationValue
            );

            return ObjectMapper.Map<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurationDto>(orangeBillPaymentNotificationConfiguration);
        }

        [Authorize(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Edit)]
        public virtual async Task<OrangeBillPaymentNotificationConfigurationDto> UpdateAsync(int id, OrangeBillPaymentNotificationConfigurationUpdateDto input)
        {

            var orangeBillPaymentNotificationConfiguration = await _orangeBillPaymentNotificationConfigurationManager.UpdateAsync(
            id,
            input.ServiceTypeName, input.ConfigurationKey, input.ConfigurationValue, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurationDto>(orangeBillPaymentNotificationConfiguration);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(OrangeBillPaymentNotificationConfigurationExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _orangeBillPaymentNotificationConfigurationRepository.GetListAsync(input.FilterText, input.ServiceTypeName, input.ConfigurationKey, input.ConfigurationValue);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<OrangeBillPaymentNotificationConfiguration>, List<OrangeBillPaymentNotificationConfigurationExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "OrangeBillPaymentNotificationConfigurations.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new OrangeBillPaymentNotificationConfigurationExcelDownloadTokenCacheItem { Token = token },
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