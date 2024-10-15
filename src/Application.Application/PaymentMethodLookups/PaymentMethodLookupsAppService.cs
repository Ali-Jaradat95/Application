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
using Application.PaymentMethodLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentMethodLookups
{

    [Authorize(ApplicationPermissions.PaymentMethodLookups.Default)]
    public abstract class PaymentMethodLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PaymentMethodLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPaymentMethodLookupRepository _paymentMethodLookupRepository;
        protected PaymentMethodLookupManager _paymentMethodLookupManager;

        public PaymentMethodLookupsAppServiceBase(IPaymentMethodLookupRepository paymentMethodLookupRepository, PaymentMethodLookupManager paymentMethodLookupManager, IDistributedCache<PaymentMethodLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _paymentMethodLookupRepository = paymentMethodLookupRepository;
            _paymentMethodLookupManager = paymentMethodLookupManager;
        }

        public virtual async Task<PagedResultDto<PaymentMethodLookupDto>> GetListAsync(GetPaymentMethodLookupsInput input)
        {
            var totalCount = await _paymentMethodLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _paymentMethodLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentMethodLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentMethodLookup>, List<PaymentMethodLookupDto>>(items)
            };
        }

        public virtual async Task<PaymentMethodLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PaymentMethodLookup, PaymentMethodLookupDto>(await _paymentMethodLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PaymentMethodLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _paymentMethodLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PaymentMethodLookups.Create)]
        public virtual async Task<PaymentMethodLookupDto> CreateAsync(PaymentMethodLookupCreateDto input)
        {

            var paymentMethodLookup = await _paymentMethodLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PaymentMethodLookup, PaymentMethodLookupDto>(paymentMethodLookup);
        }

        [Authorize(ApplicationPermissions.PaymentMethodLookups.Edit)]
        public virtual async Task<PaymentMethodLookupDto> UpdateAsync(int id, PaymentMethodLookupUpdateDto input)
        {

            var paymentMethodLookup = await _paymentMethodLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PaymentMethodLookup, PaymentMethodLookupDto>(paymentMethodLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentMethodLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _paymentMethodLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PaymentMethodLookup>, List<PaymentMethodLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PaymentMethodLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PaymentMethodLookupExcelDownloadTokenCacheItem { Token = token },
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