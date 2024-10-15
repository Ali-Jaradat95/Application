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
using Application.BillTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.BillTypeLookups
{

    [Authorize(ApplicationPermissions.BillTypeLookups.Default)]
    public abstract class BillTypeLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<BillTypeLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IBillTypeLookupRepository _billTypeLookupRepository;
        protected BillTypeLookupManager _billTypeLookupManager;

        public BillTypeLookupsAppServiceBase(IBillTypeLookupRepository billTypeLookupRepository, BillTypeLookupManager billTypeLookupManager, IDistributedCache<BillTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _billTypeLookupRepository = billTypeLookupRepository;
            _billTypeLookupManager = billTypeLookupManager;
        }

        public virtual async Task<PagedResultDto<BillTypeLookupDto>> GetListAsync(GetBillTypeLookupsInput input)
        {
            var totalCount = await _billTypeLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _billTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BillTypeLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<BillTypeLookup>, List<BillTypeLookupDto>>(items)
            };
        }

        public virtual async Task<BillTypeLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<BillTypeLookup, BillTypeLookupDto>(await _billTypeLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.BillTypeLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _billTypeLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.BillTypeLookups.Create)]
        public virtual async Task<BillTypeLookupDto> CreateAsync(BillTypeLookupCreateDto input)
        {

            var billTypeLookup = await _billTypeLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<BillTypeLookup, BillTypeLookupDto>(billTypeLookup);
        }

        [Authorize(ApplicationPermissions.BillTypeLookups.Edit)]
        public virtual async Task<BillTypeLookupDto> UpdateAsync(int id, BillTypeLookupUpdateDto input)
        {

            var billTypeLookup = await _billTypeLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<BillTypeLookup, BillTypeLookupDto>(billTypeLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillTypeLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _billTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<BillTypeLookup>, List<BillTypeLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "BillTypeLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new BillTypeLookupExcelDownloadTokenCacheItem { Token = token },
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