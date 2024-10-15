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
using Application.ServiceTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.ServiceTypeLookups
{

    [Authorize(ApplicationPermissions.ServiceTypeLookups.Default)]
    public abstract class ServiceTypeLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ServiceTypeLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IServiceTypeLookupRepository _serviceTypeLookupRepository;
        protected ServiceTypeLookupManager _serviceTypeLookupManager;

        public ServiceTypeLookupsAppServiceBase(IServiceTypeLookupRepository serviceTypeLookupRepository, ServiceTypeLookupManager serviceTypeLookupManager, IDistributedCache<ServiceTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _serviceTypeLookupRepository = serviceTypeLookupRepository;
            _serviceTypeLookupManager = serviceTypeLookupManager;
        }

        public virtual async Task<PagedResultDto<ServiceTypeLookupDto>> GetListAsync(GetServiceTypeLookupsInput input)
        {
            var totalCount = await _serviceTypeLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _serviceTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ServiceTypeLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ServiceTypeLookup>, List<ServiceTypeLookupDto>>(items)
            };
        }

        public virtual async Task<ServiceTypeLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<ServiceTypeLookup, ServiceTypeLookupDto>(await _serviceTypeLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.ServiceTypeLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _serviceTypeLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.ServiceTypeLookups.Create)]
        public virtual async Task<ServiceTypeLookupDto> CreateAsync(ServiceTypeLookupCreateDto input)
        {

            var serviceTypeLookup = await _serviceTypeLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<ServiceTypeLookup, ServiceTypeLookupDto>(serviceTypeLookup);
        }

        [Authorize(ApplicationPermissions.ServiceTypeLookups.Edit)]
        public virtual async Task<ServiceTypeLookupDto> UpdateAsync(int id, ServiceTypeLookupUpdateDto input)
        {

            var serviceTypeLookup = await _serviceTypeLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ServiceTypeLookup, ServiceTypeLookupDto>(serviceTypeLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ServiceTypeLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _serviceTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ServiceTypeLookup>, List<ServiceTypeLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ServiceTypeLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ServiceTypeLookupExcelDownloadTokenCacheItem { Token = token },
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