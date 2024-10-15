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
using Application.AccessChannelLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.AccessChannelLookups
{

    [Authorize(ApplicationPermissions.AccessChannelLookups.Default)]
    public abstract class AccessChannelLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<AccessChannelLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IAccessChannelLookupRepository _accessChannelLookupRepository;
        protected AccessChannelLookupManager _accessChannelLookupManager;

        public AccessChannelLookupsAppServiceBase(IAccessChannelLookupRepository accessChannelLookupRepository, AccessChannelLookupManager accessChannelLookupManager, IDistributedCache<AccessChannelLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _accessChannelLookupRepository = accessChannelLookupRepository;
            _accessChannelLookupManager = accessChannelLookupManager;
        }

        public virtual async Task<PagedResultDto<AccessChannelLookupDto>> GetListAsync(GetAccessChannelLookupsInput input)
        {
            var totalCount = await _accessChannelLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _accessChannelLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AccessChannelLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AccessChannelLookup>, List<AccessChannelLookupDto>>(items)
            };
        }

        public virtual async Task<AccessChannelLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<AccessChannelLookup, AccessChannelLookupDto>(await _accessChannelLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.AccessChannelLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _accessChannelLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.AccessChannelLookups.Create)]
        public virtual async Task<AccessChannelLookupDto> CreateAsync(AccessChannelLookupCreateDto input)
        {

            var accessChannelLookup = await _accessChannelLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<AccessChannelLookup, AccessChannelLookupDto>(accessChannelLookup);
        }

        [Authorize(ApplicationPermissions.AccessChannelLookups.Edit)]
        public virtual async Task<AccessChannelLookupDto> UpdateAsync(int id, AccessChannelLookupUpdateDto input)
        {

            var accessChannelLookup = await _accessChannelLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<AccessChannelLookup, AccessChannelLookupDto>(accessChannelLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(AccessChannelLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _accessChannelLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<AccessChannelLookup>, List<AccessChannelLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "AccessChannelLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new AccessChannelLookupExcelDownloadTokenCacheItem { Token = token },
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