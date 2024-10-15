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
using Application.PaymentStatusLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentStatusLookups
{

    [Authorize(ApplicationPermissions.PaymentStatusLookups.Default)]
    public abstract class PaymentStatusLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PaymentStatusLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPaymentStatusLookupRepository _paymentStatusLookupRepository;
        protected PaymentStatusLookupManager _paymentStatusLookupManager;

        public PaymentStatusLookupsAppServiceBase(IPaymentStatusLookupRepository paymentStatusLookupRepository, PaymentStatusLookupManager paymentStatusLookupManager, IDistributedCache<PaymentStatusLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _paymentStatusLookupRepository = paymentStatusLookupRepository;
            _paymentStatusLookupManager = paymentStatusLookupManager;
        }

        public virtual async Task<PagedResultDto<PaymentStatusLookupDto>> GetListAsync(GetPaymentStatusLookupsInput input)
        {
            var totalCount = await _paymentStatusLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _paymentStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentStatusLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentStatusLookup>, List<PaymentStatusLookupDto>>(items)
            };
        }

        public virtual async Task<PaymentStatusLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PaymentStatusLookup, PaymentStatusLookupDto>(await _paymentStatusLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PaymentStatusLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _paymentStatusLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PaymentStatusLookups.Create)]
        public virtual async Task<PaymentStatusLookupDto> CreateAsync(PaymentStatusLookupCreateDto input)
        {

            var paymentStatusLookup = await _paymentStatusLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PaymentStatusLookup, PaymentStatusLookupDto>(paymentStatusLookup);
        }

        [Authorize(ApplicationPermissions.PaymentStatusLookups.Edit)]
        public virtual async Task<PaymentStatusLookupDto> UpdateAsync(int id, PaymentStatusLookupUpdateDto input)
        {

            var paymentStatusLookup = await _paymentStatusLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PaymentStatusLookup, PaymentStatusLookupDto>(paymentStatusLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentStatusLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _paymentStatusLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PaymentStatusLookup>, List<PaymentStatusLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PaymentStatusLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PaymentStatusLookupExcelDownloadTokenCacheItem { Token = token },
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