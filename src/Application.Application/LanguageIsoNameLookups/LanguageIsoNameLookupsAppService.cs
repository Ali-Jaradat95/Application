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
using Application.LanguageIsoNameLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.LanguageIsoNameLookups
{

    [Authorize(ApplicationPermissions.LanguageIsoNameLookups.Default)]
    public abstract class LanguageIsoNameLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<LanguageIsoNameLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected ILanguageIsoNameLookupRepository _languageIsoNameLookupRepository;
        protected LanguageIsoNameLookupManager _languageIsoNameLookupManager;

        public LanguageIsoNameLookupsAppServiceBase(ILanguageIsoNameLookupRepository languageIsoNameLookupRepository, LanguageIsoNameLookupManager languageIsoNameLookupManager, IDistributedCache<LanguageIsoNameLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _languageIsoNameLookupRepository = languageIsoNameLookupRepository;
            _languageIsoNameLookupManager = languageIsoNameLookupManager;
        }

        public virtual async Task<PagedResultDto<LanguageIsoNameLookupDto>> GetListAsync(GetLanguageIsoNameLookupsInput input)
        {
            var totalCount = await _languageIsoNameLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _languageIsoNameLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<LanguageIsoNameLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<LanguageIsoNameLookup>, List<LanguageIsoNameLookupDto>>(items)
            };
        }

        public virtual async Task<LanguageIsoNameLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<LanguageIsoNameLookup, LanguageIsoNameLookupDto>(await _languageIsoNameLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.LanguageIsoNameLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _languageIsoNameLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.LanguageIsoNameLookups.Create)]
        public virtual async Task<LanguageIsoNameLookupDto> CreateAsync(LanguageIsoNameLookupCreateDto input)
        {

            var languageIsoNameLookup = await _languageIsoNameLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<LanguageIsoNameLookup, LanguageIsoNameLookupDto>(languageIsoNameLookup);
        }

        [Authorize(ApplicationPermissions.LanguageIsoNameLookups.Edit)]
        public virtual async Task<LanguageIsoNameLookupDto> UpdateAsync(int id, LanguageIsoNameLookupUpdateDto input)
        {

            var languageIsoNameLookup = await _languageIsoNameLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<LanguageIsoNameLookup, LanguageIsoNameLookupDto>(languageIsoNameLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(LanguageIsoNameLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _languageIsoNameLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<LanguageIsoNameLookup>, List<LanguageIsoNameLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "LanguageIsoNameLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new LanguageIsoNameLookupExcelDownloadTokenCacheItem { Token = token },
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