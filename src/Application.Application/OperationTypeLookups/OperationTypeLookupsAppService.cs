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
using Application.OperationTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.OperationTypeLookups
{

    [Authorize(ApplicationPermissions.OperationTypeLookups.Default)]
    public abstract class OperationTypeLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<OperationTypeLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IOperationTypeLookupRepository _operationTypeLookupRepository;
        protected OperationTypeLookupManager _operationTypeLookupManager;

        public OperationTypeLookupsAppServiceBase(IOperationTypeLookupRepository operationTypeLookupRepository, OperationTypeLookupManager operationTypeLookupManager, IDistributedCache<OperationTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _operationTypeLookupRepository = operationTypeLookupRepository;
            _operationTypeLookupManager = operationTypeLookupManager;
        }

        public virtual async Task<PagedResultDto<OperationTypeLookupDto>> GetListAsync(GetOperationTypeLookupsInput input)
        {
            var totalCount = await _operationTypeLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _operationTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<OperationTypeLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<OperationTypeLookup>, List<OperationTypeLookupDto>>(items)
            };
        }

        public virtual async Task<OperationTypeLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<OperationTypeLookup, OperationTypeLookupDto>(await _operationTypeLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.OperationTypeLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _operationTypeLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.OperationTypeLookups.Create)]
        public virtual async Task<OperationTypeLookupDto> CreateAsync(OperationTypeLookupCreateDto input)
        {

            var operationTypeLookup = await _operationTypeLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<OperationTypeLookup, OperationTypeLookupDto>(operationTypeLookup);
        }

        [Authorize(ApplicationPermissions.OperationTypeLookups.Edit)]
        public virtual async Task<OperationTypeLookupDto> UpdateAsync(int id, OperationTypeLookupUpdateDto input)
        {

            var operationTypeLookup = await _operationTypeLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<OperationTypeLookup, OperationTypeLookupDto>(operationTypeLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(OperationTypeLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _operationTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<OperationTypeLookup>, List<OperationTypeLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "OperationTypeLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new OperationTypeLookupExcelDownloadTokenCacheItem { Token = token },
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