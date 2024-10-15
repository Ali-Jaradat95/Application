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
using Application.PrepaidValidationConfigs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PrepaidValidationConfigs
{

    [Authorize(ApplicationPermissions.PrepaidValidationConfigs.Default)]
    public abstract class PrepaidValidationConfigsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PrepaidValidationConfigExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPrepaidValidationConfigRepository _prepaidValidationConfigRepository;
        protected PrepaidValidationConfigManager _prepaidValidationConfigManager;

        public PrepaidValidationConfigsAppServiceBase(IPrepaidValidationConfigRepository prepaidValidationConfigRepository, PrepaidValidationConfigManager prepaidValidationConfigManager, IDistributedCache<PrepaidValidationConfigExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _prepaidValidationConfigRepository = prepaidValidationConfigRepository;
            _prepaidValidationConfigManager = prepaidValidationConfigManager;
        }

        public virtual async Task<PagedResultDto<PrepaidValidationConfigDto>> GetListAsync(GetPrepaidValidationConfigsInput input)
        {
            var totalCount = await _prepaidValidationConfigRepository.GetCountAsync(input.FilterText, input.ServiceType, input.ChannelCode, input.BillingName, input.AliasBillingName, input.IsTesting, input.EndpointUrl);
            var items = await _prepaidValidationConfigRepository.GetListAsync(input.FilterText, input.ServiceType, input.ChannelCode, input.BillingName, input.AliasBillingName, input.IsTesting, input.EndpointUrl, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PrepaidValidationConfigDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PrepaidValidationConfig>, List<PrepaidValidationConfigDto>>(items)
            };
        }

        public virtual async Task<PrepaidValidationConfigDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PrepaidValidationConfig, PrepaidValidationConfigDto>(await _prepaidValidationConfigRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PrepaidValidationConfigs.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _prepaidValidationConfigRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PrepaidValidationConfigs.Create)]
        public virtual async Task<PrepaidValidationConfigDto> CreateAsync(PrepaidValidationConfigCreateDto input)
        {

            var prepaidValidationConfig = await _prepaidValidationConfigManager.CreateAsync(
            input.ServiceType, input.IsTesting, input.ChannelCode, input.BillingName, input.AliasBillingName, input.EndpointUrl
            );

            return ObjectMapper.Map<PrepaidValidationConfig, PrepaidValidationConfigDto>(prepaidValidationConfig);
        }

        [Authorize(ApplicationPermissions.PrepaidValidationConfigs.Edit)]
        public virtual async Task<PrepaidValidationConfigDto> UpdateAsync(int id, PrepaidValidationConfigUpdateDto input)
        {

            var prepaidValidationConfig = await _prepaidValidationConfigManager.UpdateAsync(
            id,
            input.ServiceType, input.IsTesting, input.ChannelCode, input.BillingName, input.AliasBillingName, input.EndpointUrl, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PrepaidValidationConfig, PrepaidValidationConfigDto>(prepaidValidationConfig);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PrepaidValidationConfigExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _prepaidValidationConfigRepository.GetListAsync(input.FilterText, input.ServiceType, input.ChannelCode, input.BillingName, input.AliasBillingName, input.IsTesting, input.EndpointUrl);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PrepaidValidationConfig>, List<PrepaidValidationConfigExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PrepaidValidationConfigs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PrepaidValidationConfigExcelDownloadTokenCacheItem { Token = token },
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