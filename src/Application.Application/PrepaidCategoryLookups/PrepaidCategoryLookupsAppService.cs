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
using Application.PrepaidCategoryLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PrepaidCategoryLookups
{

    [Authorize(ApplicationPermissions.PrepaidCategoryLookups.Default)]
    public abstract class PrepaidCategoryLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PrepaidCategoryLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPrepaidCategoryLookupRepository _prepaidCategoryLookupRepository;
        protected PrepaidCategoryLookupManager _prepaidCategoryLookupManager;

        public PrepaidCategoryLookupsAppServiceBase(IPrepaidCategoryLookupRepository prepaidCategoryLookupRepository, PrepaidCategoryLookupManager prepaidCategoryLookupManager, IDistributedCache<PrepaidCategoryLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _prepaidCategoryLookupRepository = prepaidCategoryLookupRepository;
            _prepaidCategoryLookupManager = prepaidCategoryLookupManager;
        }

        public virtual async Task<PagedResultDto<PrepaidCategoryLookupDto>> GetListAsync(GetPrepaidCategoryLookupsInput input)
        {
            var totalCount = await _prepaidCategoryLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _prepaidCategoryLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PrepaidCategoryLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PrepaidCategoryLookup>, List<PrepaidCategoryLookupDto>>(items)
            };
        }

        public virtual async Task<PrepaidCategoryLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PrepaidCategoryLookup, PrepaidCategoryLookupDto>(await _prepaidCategoryLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PrepaidCategoryLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _prepaidCategoryLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PrepaidCategoryLookups.Create)]
        public virtual async Task<PrepaidCategoryLookupDto> CreateAsync(PrepaidCategoryLookupCreateDto input)
        {

            var prepaidCategoryLookup = await _prepaidCategoryLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PrepaidCategoryLookup, PrepaidCategoryLookupDto>(prepaidCategoryLookup);
        }

        [Authorize(ApplicationPermissions.PrepaidCategoryLookups.Edit)]
        public virtual async Task<PrepaidCategoryLookupDto> UpdateAsync(int id, PrepaidCategoryLookupUpdateDto input)
        {

            var prepaidCategoryLookup = await _prepaidCategoryLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PrepaidCategoryLookup, PrepaidCategoryLookupDto>(prepaidCategoryLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PrepaidCategoryLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _prepaidCategoryLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PrepaidCategoryLookup>, List<PrepaidCategoryLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PrepaidCategoryLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PrepaidCategoryLookupExcelDownloadTokenCacheItem { Token = token },
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