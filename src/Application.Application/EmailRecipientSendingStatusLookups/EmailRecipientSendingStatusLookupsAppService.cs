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
using Application.EmailRecipientSendingStatusLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.EmailRecipientSendingStatusLookups
{

    [Authorize(ApplicationPermissions.EmailRecipientSendingStatusLookups.Default)]
    public abstract class EmailRecipientSendingStatusLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<EmailRecipientSendingStatusLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IEmailRecipientSendingStatusLookupRepository _emailRecipientSendingStatusLookupRepository;
        protected EmailRecipientSendingStatusLookupManager _emailRecipientSendingStatusLookupManager;

        public EmailRecipientSendingStatusLookupsAppServiceBase(IEmailRecipientSendingStatusLookupRepository emailRecipientSendingStatusLookupRepository, EmailRecipientSendingStatusLookupManager emailRecipientSendingStatusLookupManager, IDistributedCache<EmailRecipientSendingStatusLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _emailRecipientSendingStatusLookupRepository = emailRecipientSendingStatusLookupRepository;
            _emailRecipientSendingStatusLookupManager = emailRecipientSendingStatusLookupManager;
        }

        public virtual async Task<PagedResultDto<EmailRecipientSendingStatusLookupDto>> GetListAsync(GetEmailRecipientSendingStatusLookupsInput input)
        {
            var totalCount = await _emailRecipientSendingStatusLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _emailRecipientSendingStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<EmailRecipientSendingStatusLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<EmailRecipientSendingStatusLookup>, List<EmailRecipientSendingStatusLookupDto>>(items)
            };
        }

        public virtual async Task<EmailRecipientSendingStatusLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookupDto>(await _emailRecipientSendingStatusLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.EmailRecipientSendingStatusLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _emailRecipientSendingStatusLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.EmailRecipientSendingStatusLookups.Create)]
        public virtual async Task<EmailRecipientSendingStatusLookupDto> CreateAsync(EmailRecipientSendingStatusLookupCreateDto input)
        {

            var emailRecipientSendingStatusLookup = await _emailRecipientSendingStatusLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookupDto>(emailRecipientSendingStatusLookup);
        }

        [Authorize(ApplicationPermissions.EmailRecipientSendingStatusLookups.Edit)]
        public virtual async Task<EmailRecipientSendingStatusLookupDto> UpdateAsync(int id, EmailRecipientSendingStatusLookupUpdateDto input)
        {

            var emailRecipientSendingStatusLookup = await _emailRecipientSendingStatusLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookupDto>(emailRecipientSendingStatusLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(EmailRecipientSendingStatusLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _emailRecipientSendingStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<EmailRecipientSendingStatusLookup>, List<EmailRecipientSendingStatusLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "EmailRecipientSendingStatusLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new EmailRecipientSendingStatusLookupExcelDownloadTokenCacheItem { Token = token },
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