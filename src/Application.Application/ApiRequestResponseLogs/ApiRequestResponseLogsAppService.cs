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
using Application.ApiRequestResponseLogs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.ApiRequestResponseLogs
{

    [Authorize(ApplicationPermissions.ApiRequestResponseLogs.Default)]
    public abstract class ApiRequestResponseLogsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ApiRequestResponseLogExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IApiRequestResponseLogRepository _apiRequestResponseLogRepository;
        protected ApiRequestResponseLogManager _apiRequestResponseLogManager;

        public ApiRequestResponseLogsAppServiceBase(IApiRequestResponseLogRepository apiRequestResponseLogRepository, ApiRequestResponseLogManager apiRequestResponseLogManager, IDistributedCache<ApiRequestResponseLogExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _apiRequestResponseLogRepository = apiRequestResponseLogRepository;
            _apiRequestResponseLogManager = apiRequestResponseLogManager;
        }

        public virtual async Task<PagedResultDto<ApiRequestResponseLogDto>> GetListAsync(GetApiRequestResponseLogsInput input)
        {
            var totalCount = await _apiRequestResponseLogRepository.GetCountAsync(input.FilterText, input.RequestUrl, input.RequestMethod, input.RequestHeaders, input.RequestBody, input.ResponseBody, input.ResponseStatusCodeMin, input.ResponseStatusCodeMax, input.ResponseHeaders, input.DurationMsMin, input.DurationMsMax, input.CreatedAtMin, input.CreatedAtMax, input.CorrelationId, input.IpAddress, input.UserId, input.ErrorDetails, input.IsSuccessful, input.SourceSystem);
            var items = await _apiRequestResponseLogRepository.GetListAsync(input.FilterText, input.RequestUrl, input.RequestMethod, input.RequestHeaders, input.RequestBody, input.ResponseBody, input.ResponseStatusCodeMin, input.ResponseStatusCodeMax, input.ResponseHeaders, input.DurationMsMin, input.DurationMsMax, input.CreatedAtMin, input.CreatedAtMax, input.CorrelationId, input.IpAddress, input.UserId, input.ErrorDetails, input.IsSuccessful, input.SourceSystem, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ApiRequestResponseLogDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ApiRequestResponseLog>, List<ApiRequestResponseLogDto>>(items)
            };
        }

        public virtual async Task<ApiRequestResponseLogDto> GetAsync(int id)
        {
            return ObjectMapper.Map<ApiRequestResponseLog, ApiRequestResponseLogDto>(await _apiRequestResponseLogRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.ApiRequestResponseLogs.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _apiRequestResponseLogRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.ApiRequestResponseLogs.Create)]
        public virtual async Task<ApiRequestResponseLogDto> CreateAsync(ApiRequestResponseLogCreateDto input)
        {

            var apiRequestResponseLog = await _apiRequestResponseLogManager.CreateAsync(
            input.IsSuccessful, input.RequestUrl, input.RequestMethod, input.RequestHeaders, input.RequestBody, input.ResponseBody, input.ResponseStatusCode, input.ResponseHeaders, input.DurationMs, input.CreatedAt, input.CorrelationId, input.IpAddress, input.UserId, input.ErrorDetails, input.SourceSystem
            );

            return ObjectMapper.Map<ApiRequestResponseLog, ApiRequestResponseLogDto>(apiRequestResponseLog);
        }

        [Authorize(ApplicationPermissions.ApiRequestResponseLogs.Edit)]
        public virtual async Task<ApiRequestResponseLogDto> UpdateAsync(int id, ApiRequestResponseLogUpdateDto input)
        {

            var apiRequestResponseLog = await _apiRequestResponseLogManager.UpdateAsync(
            id,
            input.IsSuccessful, input.RequestUrl, input.RequestMethod, input.RequestHeaders, input.RequestBody, input.ResponseBody, input.ResponseStatusCode, input.ResponseHeaders, input.DurationMs, input.CreatedAt, input.CorrelationId, input.IpAddress, input.UserId, input.ErrorDetails, input.SourceSystem, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ApiRequestResponseLog, ApiRequestResponseLogDto>(apiRequestResponseLog);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ApiRequestResponseLogExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _apiRequestResponseLogRepository.GetListAsync(input.FilterText, input.RequestUrl, input.RequestMethod, input.RequestHeaders, input.RequestBody, input.ResponseBody, input.ResponseStatusCodeMin, input.ResponseStatusCodeMax, input.ResponseHeaders, input.DurationMsMin, input.DurationMsMax, input.CreatedAtMin, input.CreatedAtMax, input.CorrelationId, input.IpAddress, input.UserId, input.ErrorDetails, input.IsSuccessful, input.SourceSystem);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ApiRequestResponseLog>, List<ApiRequestResponseLogExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ApiRequestResponseLogs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ApiRequestResponseLogExcelDownloadTokenCacheItem { Token = token },
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