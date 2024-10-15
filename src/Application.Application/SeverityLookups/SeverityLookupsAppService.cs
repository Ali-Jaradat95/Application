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
using Application.SeverityLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.SeverityLookups
{

    [Authorize(ApplicationPermissions.SeverityLookups.Default)]
    public abstract class SeverityLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<SeverityLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected ISeverityLookupRepository _severityLookupRepository;
        protected SeverityLookupManager _severityLookupManager;

        public SeverityLookupsAppServiceBase(ISeverityLookupRepository severityLookupRepository, SeverityLookupManager severityLookupManager, IDistributedCache<SeverityLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _severityLookupRepository = severityLookupRepository;
            _severityLookupManager = severityLookupManager;
        }

        public virtual async Task<PagedResultDto<SeverityLookupDto>> GetListAsync(GetSeverityLookupsInput input)
        {
            var totalCount = await _severityLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _severityLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SeverityLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SeverityLookup>, List<SeverityLookupDto>>(items)
            };
        }

        public virtual async Task<SeverityLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<SeverityLookup, SeverityLookupDto>(await _severityLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.SeverityLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _severityLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.SeverityLookups.Create)]
        public virtual async Task<SeverityLookupDto> CreateAsync(SeverityLookupCreateDto input)
        {

            var severityLookup = await _severityLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<SeverityLookup, SeverityLookupDto>(severityLookup);
        }

        [Authorize(ApplicationPermissions.SeverityLookups.Edit)]
        public virtual async Task<SeverityLookupDto> UpdateAsync(int id, SeverityLookupUpdateDto input)
        {

            var severityLookup = await _severityLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<SeverityLookup, SeverityLookupDto>(severityLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SeverityLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _severityLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SeverityLookup>, List<SeverityLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SeverityLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SeverityLookupExcelDownloadTokenCacheItem { Token = token },
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