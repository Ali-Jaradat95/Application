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
using Application.PaymentCurrencyLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentCurrencyLookups
{

    [Authorize(ApplicationPermissions.PaymentCurrencyLookups.Default)]
    public abstract class PaymentCurrencyLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PaymentCurrencyLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPaymentCurrencyLookupRepository _paymentCurrencyLookupRepository;
        protected PaymentCurrencyLookupManager _paymentCurrencyLookupManager;

        public PaymentCurrencyLookupsAppServiceBase(IPaymentCurrencyLookupRepository paymentCurrencyLookupRepository, PaymentCurrencyLookupManager paymentCurrencyLookupManager, IDistributedCache<PaymentCurrencyLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _paymentCurrencyLookupRepository = paymentCurrencyLookupRepository;
            _paymentCurrencyLookupManager = paymentCurrencyLookupManager;
        }

        public virtual async Task<PagedResultDto<PaymentCurrencyLookupDto>> GetListAsync(GetPaymentCurrencyLookupsInput input)
        {
            var totalCount = await _paymentCurrencyLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _paymentCurrencyLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentCurrencyLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentCurrencyLookup>, List<PaymentCurrencyLookupDto>>(items)
            };
        }

        public virtual async Task<PaymentCurrencyLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PaymentCurrencyLookup, PaymentCurrencyLookupDto>(await _paymentCurrencyLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PaymentCurrencyLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _paymentCurrencyLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PaymentCurrencyLookups.Create)]
        public virtual async Task<PaymentCurrencyLookupDto> CreateAsync(PaymentCurrencyLookupCreateDto input)
        {

            var paymentCurrencyLookup = await _paymentCurrencyLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PaymentCurrencyLookup, PaymentCurrencyLookupDto>(paymentCurrencyLookup);
        }

        [Authorize(ApplicationPermissions.PaymentCurrencyLookups.Edit)]
        public virtual async Task<PaymentCurrencyLookupDto> UpdateAsync(int id, PaymentCurrencyLookupUpdateDto input)
        {

            var paymentCurrencyLookup = await _paymentCurrencyLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PaymentCurrencyLookup, PaymentCurrencyLookupDto>(paymentCurrencyLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentCurrencyLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _paymentCurrencyLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PaymentCurrencyLookup>, List<PaymentCurrencyLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PaymentCurrencyLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PaymentCurrencyLookupExcelDownloadTokenCacheItem { Token = token },
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