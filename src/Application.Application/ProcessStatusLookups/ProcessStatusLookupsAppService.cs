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
using Application.ProcessStatusLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.ProcessStatusLookups
{

    [Authorize(ApplicationPermissions.ProcessStatusLookups.Default)]
    public abstract class ProcessStatusLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ProcessStatusLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IProcessStatusLookupRepository _processStatusLookupRepository;
        protected ProcessStatusLookupManager _processStatusLookupManager;

        public ProcessStatusLookupsAppServiceBase(IProcessStatusLookupRepository processStatusLookupRepository, ProcessStatusLookupManager processStatusLookupManager, IDistributedCache<ProcessStatusLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _processStatusLookupRepository = processStatusLookupRepository;
            _processStatusLookupManager = processStatusLookupManager;
        }

        public virtual async Task<PagedResultDto<ProcessStatusLookupDto>> GetListAsync(GetProcessStatusLookupsInput input)
        {
            var totalCount = await _processStatusLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _processStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ProcessStatusLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ProcessStatusLookup>, List<ProcessStatusLookupDto>>(items)
            };
        }

        public virtual async Task<ProcessStatusLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<ProcessStatusLookup, ProcessStatusLookupDto>(await _processStatusLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.ProcessStatusLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _processStatusLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.ProcessStatusLookups.Create)]
        public virtual async Task<ProcessStatusLookupDto> CreateAsync(ProcessStatusLookupCreateDto input)
        {

            var processStatusLookup = await _processStatusLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<ProcessStatusLookup, ProcessStatusLookupDto>(processStatusLookup);
        }

        [Authorize(ApplicationPermissions.ProcessStatusLookups.Edit)]
        public virtual async Task<ProcessStatusLookupDto> UpdateAsync(int id, ProcessStatusLookupUpdateDto input)
        {

            var processStatusLookup = await _processStatusLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ProcessStatusLookup, ProcessStatusLookupDto>(processStatusLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ProcessStatusLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _processStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ProcessStatusLookup>, List<ProcessStatusLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ProcessStatusLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ProcessStatusLookupExcelDownloadTokenCacheItem { Token = token },
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