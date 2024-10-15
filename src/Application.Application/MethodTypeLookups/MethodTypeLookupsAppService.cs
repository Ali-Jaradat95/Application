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
using Application.MethodTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.MethodTypeLookups
{

    [Authorize(ApplicationPermissions.MethodTypeLookups.Default)]
    public abstract class MethodTypeLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MethodTypeLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IMethodTypeLookupRepository _methodTypeLookupRepository;
        protected MethodTypeLookupManager _methodTypeLookupManager;

        public MethodTypeLookupsAppServiceBase(IMethodTypeLookupRepository methodTypeLookupRepository, MethodTypeLookupManager methodTypeLookupManager, IDistributedCache<MethodTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _methodTypeLookupRepository = methodTypeLookupRepository;
            _methodTypeLookupManager = methodTypeLookupManager;
        }

        public virtual async Task<PagedResultDto<MethodTypeLookupDto>> GetListAsync(GetMethodTypeLookupsInput input)
        {
            var totalCount = await _methodTypeLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _methodTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MethodTypeLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MethodTypeLookup>, List<MethodTypeLookupDto>>(items)
            };
        }

        public virtual async Task<MethodTypeLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MethodTypeLookup, MethodTypeLookupDto>(await _methodTypeLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.MethodTypeLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _methodTypeLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.MethodTypeLookups.Create)]
        public virtual async Task<MethodTypeLookupDto> CreateAsync(MethodTypeLookupCreateDto input)
        {

            var methodTypeLookup = await _methodTypeLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<MethodTypeLookup, MethodTypeLookupDto>(methodTypeLookup);
        }

        [Authorize(ApplicationPermissions.MethodTypeLookups.Edit)]
        public virtual async Task<MethodTypeLookupDto> UpdateAsync(int id, MethodTypeLookupUpdateDto input)
        {

            var methodTypeLookup = await _methodTypeLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MethodTypeLookup, MethodTypeLookupDto>(methodTypeLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MethodTypeLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _methodTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MethodTypeLookup>, List<MethodTypeLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MethodTypeLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MethodTypeLookupExcelDownloadTokenCacheItem { Token = token },
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