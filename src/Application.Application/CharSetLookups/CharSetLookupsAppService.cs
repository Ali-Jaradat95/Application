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
using Application.CharSetLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.CharSetLookups
{

    [Authorize(ApplicationPermissions.CharSetLookups.Default)]
    public abstract class CharSetLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<CharSetLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected ICharSetLookupRepository _charSetLookupRepository;
        protected CharSetLookupManager _charSetLookupManager;

        public CharSetLookupsAppServiceBase(ICharSetLookupRepository charSetLookupRepository, CharSetLookupManager charSetLookupManager, IDistributedCache<CharSetLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _charSetLookupRepository = charSetLookupRepository;
            _charSetLookupManager = charSetLookupManager;
        }

        public virtual async Task<PagedResultDto<CharSetLookupDto>> GetListAsync(GetCharSetLookupsInput input)
        {
            var totalCount = await _charSetLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _charSetLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CharSetLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CharSetLookup>, List<CharSetLookupDto>>(items)
            };
        }

        public virtual async Task<CharSetLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<CharSetLookup, CharSetLookupDto>(await _charSetLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.CharSetLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _charSetLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.CharSetLookups.Create)]
        public virtual async Task<CharSetLookupDto> CreateAsync(CharSetLookupCreateDto input)
        {

            var charSetLookup = await _charSetLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<CharSetLookup, CharSetLookupDto>(charSetLookup);
        }

        [Authorize(ApplicationPermissions.CharSetLookups.Edit)]
        public virtual async Task<CharSetLookupDto> UpdateAsync(int id, CharSetLookupUpdateDto input)
        {

            var charSetLookup = await _charSetLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CharSetLookup, CharSetLookupDto>(charSetLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CharSetLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _charSetLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CharSetLookup>, List<CharSetLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CharSetLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CharSetLookupExcelDownloadTokenCacheItem { Token = token },
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