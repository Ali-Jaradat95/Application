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
using Application.BillStatusLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.BillStatusLookups
{

    [Authorize(ApplicationPermissions.BillStatusLookups.Default)]
    public abstract class BillStatusLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<BillStatusLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IBillStatusLookupRepository _billStatusLookupRepository;
        protected BillStatusLookupManager _billStatusLookupManager;

        public BillStatusLookupsAppServiceBase(IBillStatusLookupRepository billStatusLookupRepository, BillStatusLookupManager billStatusLookupManager, IDistributedCache<BillStatusLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _billStatusLookupRepository = billStatusLookupRepository;
            _billStatusLookupManager = billStatusLookupManager;
        }

        public virtual async Task<PagedResultDto<BillStatusLookupDto>> GetListAsync(GetBillStatusLookupsInput input)
        {
            var totalCount = await _billStatusLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _billStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BillStatusLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<BillStatusLookup>, List<BillStatusLookupDto>>(items)
            };
        }

        public virtual async Task<BillStatusLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<BillStatusLookup, BillStatusLookupDto>(await _billStatusLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.BillStatusLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _billStatusLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.BillStatusLookups.Create)]
        public virtual async Task<BillStatusLookupDto> CreateAsync(BillStatusLookupCreateDto input)
        {

            var billStatusLookup = await _billStatusLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<BillStatusLookup, BillStatusLookupDto>(billStatusLookup);
        }

        [Authorize(ApplicationPermissions.BillStatusLookups.Edit)]
        public virtual async Task<BillStatusLookupDto> UpdateAsync(int id, BillStatusLookupUpdateDto input)
        {

            var billStatusLookup = await _billStatusLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<BillStatusLookup, BillStatusLookupDto>(billStatusLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillStatusLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _billStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<BillStatusLookup>, List<BillStatusLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "BillStatusLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new BillStatusLookupExcelDownloadTokenCacheItem { Token = token },
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