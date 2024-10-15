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
using Application.BillingStatusLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.BillingStatusLookups
{

    [Authorize(ApplicationPermissions.BillingStatusLookups.Default)]
    public abstract class BillingStatusLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<BillingStatusLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IBillingStatusLookupRepository _billingStatusLookupRepository;
        protected BillingStatusLookupManager _billingStatusLookupManager;

        public BillingStatusLookupsAppServiceBase(IBillingStatusLookupRepository billingStatusLookupRepository, BillingStatusLookupManager billingStatusLookupManager, IDistributedCache<BillingStatusLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _billingStatusLookupRepository = billingStatusLookupRepository;
            _billingStatusLookupManager = billingStatusLookupManager;
        }

        public virtual async Task<PagedResultDto<BillingStatusLookupDto>> GetListAsync(GetBillingStatusLookupsInput input)
        {
            var totalCount = await _billingStatusLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _billingStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BillingStatusLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<BillingStatusLookup>, List<BillingStatusLookupDto>>(items)
            };
        }

        public virtual async Task<BillingStatusLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<BillingStatusLookup, BillingStatusLookupDto>(await _billingStatusLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.BillingStatusLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _billingStatusLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.BillingStatusLookups.Create)]
        public virtual async Task<BillingStatusLookupDto> CreateAsync(BillingStatusLookupCreateDto input)
        {

            var billingStatusLookup = await _billingStatusLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<BillingStatusLookup, BillingStatusLookupDto>(billingStatusLookup);
        }

        [Authorize(ApplicationPermissions.BillingStatusLookups.Edit)]
        public virtual async Task<BillingStatusLookupDto> UpdateAsync(int id, BillingStatusLookupUpdateDto input)
        {

            var billingStatusLookup = await _billingStatusLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<BillingStatusLookup, BillingStatusLookupDto>(billingStatusLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillingStatusLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _billingStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<BillingStatusLookup>, List<BillingStatusLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "BillingStatusLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new BillingStatusLookupExcelDownloadTokenCacheItem { Token = token },
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