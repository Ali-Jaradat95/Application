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
using Application.PaymentSourceLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentSourceLookups
{

    [Authorize(ApplicationPermissions.PaymentSourceLookups.Default)]
    public abstract class PaymentSourceLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PaymentSourceLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPaymentSourceLookupRepository _paymentSourceLookupRepository;
        protected PaymentSourceLookupManager _paymentSourceLookupManager;

        public PaymentSourceLookupsAppServiceBase(IPaymentSourceLookupRepository paymentSourceLookupRepository, PaymentSourceLookupManager paymentSourceLookupManager, IDistributedCache<PaymentSourceLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _paymentSourceLookupRepository = paymentSourceLookupRepository;
            _paymentSourceLookupManager = paymentSourceLookupManager;
        }

        public virtual async Task<PagedResultDto<PaymentSourceLookupDto>> GetListAsync(GetPaymentSourceLookupsInput input)
        {
            var totalCount = await _paymentSourceLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _paymentSourceLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentSourceLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentSourceLookup>, List<PaymentSourceLookupDto>>(items)
            };
        }

        public virtual async Task<PaymentSourceLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PaymentSourceLookup, PaymentSourceLookupDto>(await _paymentSourceLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PaymentSourceLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _paymentSourceLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PaymentSourceLookups.Create)]
        public virtual async Task<PaymentSourceLookupDto> CreateAsync(PaymentSourceLookupCreateDto input)
        {

            var paymentSourceLookup = await _paymentSourceLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PaymentSourceLookup, PaymentSourceLookupDto>(paymentSourceLookup);
        }

        [Authorize(ApplicationPermissions.PaymentSourceLookups.Edit)]
        public virtual async Task<PaymentSourceLookupDto> UpdateAsync(int id, PaymentSourceLookupUpdateDto input)
        {

            var paymentSourceLookup = await _paymentSourceLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PaymentSourceLookup, PaymentSourceLookupDto>(paymentSourceLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentSourceLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _paymentSourceLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PaymentSourceLookup>, List<PaymentSourceLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PaymentSourceLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PaymentSourceLookupExcelDownloadTokenCacheItem { Token = token },
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