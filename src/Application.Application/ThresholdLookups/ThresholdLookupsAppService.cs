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
using Application.ThresholdLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.ThresholdLookups
{

    [Authorize(ApplicationPermissions.ThresholdLookups.Default)]
    public abstract class ThresholdLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ThresholdLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IThresholdLookupRepository _thresholdLookupRepository;
        protected ThresholdLookupManager _thresholdLookupManager;

        public ThresholdLookupsAppServiceBase(IThresholdLookupRepository thresholdLookupRepository, ThresholdLookupManager thresholdLookupManager, IDistributedCache<ThresholdLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _thresholdLookupRepository = thresholdLookupRepository;
            _thresholdLookupManager = thresholdLookupManager;
        }

        public virtual async Task<PagedResultDto<ThresholdLookupDto>> GetListAsync(GetThresholdLookupsInput input)
        {
            var totalCount = await _thresholdLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _thresholdLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ThresholdLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ThresholdLookup>, List<ThresholdLookupDto>>(items)
            };
        }

        public virtual async Task<ThresholdLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<ThresholdLookup, ThresholdLookupDto>(await _thresholdLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.ThresholdLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _thresholdLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.ThresholdLookups.Create)]
        public virtual async Task<ThresholdLookupDto> CreateAsync(ThresholdLookupCreateDto input)
        {

            var thresholdLookup = await _thresholdLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<ThresholdLookup, ThresholdLookupDto>(thresholdLookup);
        }

        [Authorize(ApplicationPermissions.ThresholdLookups.Edit)]
        public virtual async Task<ThresholdLookupDto> UpdateAsync(int id, ThresholdLookupUpdateDto input)
        {

            var thresholdLookup = await _thresholdLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ThresholdLookup, ThresholdLookupDto>(thresholdLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ThresholdLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _thresholdLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ThresholdLookup>, List<ThresholdLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ThresholdLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ThresholdLookupExcelDownloadTokenCacheItem { Token = token },
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