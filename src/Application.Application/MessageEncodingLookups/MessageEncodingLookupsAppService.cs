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
using Application.MessageEncodingLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.MessageEncodingLookups
{

    [Authorize(ApplicationPermissions.MessageEncodingLookups.Default)]
    public abstract class MessageEncodingLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MessageEncodingLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IMessageEncodingLookupRepository _messageEncodingLookupRepository;
        protected MessageEncodingLookupManager _messageEncodingLookupManager;

        public MessageEncodingLookupsAppServiceBase(IMessageEncodingLookupRepository messageEncodingLookupRepository, MessageEncodingLookupManager messageEncodingLookupManager, IDistributedCache<MessageEncodingLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _messageEncodingLookupRepository = messageEncodingLookupRepository;
            _messageEncodingLookupManager = messageEncodingLookupManager;
        }

        public virtual async Task<PagedResultDto<MessageEncodingLookupDto>> GetListAsync(GetMessageEncodingLookupsInput input)
        {
            var totalCount = await _messageEncodingLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _messageEncodingLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MessageEncodingLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MessageEncodingLookup>, List<MessageEncodingLookupDto>>(items)
            };
        }

        public virtual async Task<MessageEncodingLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MessageEncodingLookup, MessageEncodingLookupDto>(await _messageEncodingLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.MessageEncodingLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _messageEncodingLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.MessageEncodingLookups.Create)]
        public virtual async Task<MessageEncodingLookupDto> CreateAsync(MessageEncodingLookupCreateDto input)
        {

            var messageEncodingLookup = await _messageEncodingLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<MessageEncodingLookup, MessageEncodingLookupDto>(messageEncodingLookup);
        }

        [Authorize(ApplicationPermissions.MessageEncodingLookups.Edit)]
        public virtual async Task<MessageEncodingLookupDto> UpdateAsync(int id, MessageEncodingLookupUpdateDto input)
        {

            var messageEncodingLookup = await _messageEncodingLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MessageEncodingLookup, MessageEncodingLookupDto>(messageEncodingLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MessageEncodingLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _messageEncodingLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MessageEncodingLookup>, List<MessageEncodingLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MessageEncodingLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MessageEncodingLookupExcelDownloadTokenCacheItem { Token = token },
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