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
using Application.PaymentTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentTypeLookups
{

    [Authorize(ApplicationPermissions.PaymentTypeLookups.Default)]
    public abstract class PaymentTypeLookupsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PaymentTypeLookupExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IPaymentTypeLookupRepository _paymentTypeLookupRepository;
        protected PaymentTypeLookupManager _paymentTypeLookupManager;

        public PaymentTypeLookupsAppServiceBase(IPaymentTypeLookupRepository paymentTypeLookupRepository, PaymentTypeLookupManager paymentTypeLookupManager, IDistributedCache<PaymentTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _paymentTypeLookupRepository = paymentTypeLookupRepository;
            _paymentTypeLookupManager = paymentTypeLookupManager;
        }

        public virtual async Task<PagedResultDto<PaymentTypeLookupDto>> GetListAsync(GetPaymentTypeLookupsInput input)
        {
            var totalCount = await _paymentTypeLookupRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Description);
            var items = await _paymentTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PaymentTypeLookupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PaymentTypeLookup>, List<PaymentTypeLookupDto>>(items)
            };
        }

        public virtual async Task<PaymentTypeLookupDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PaymentTypeLookup, PaymentTypeLookupDto>(await _paymentTypeLookupRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.PaymentTypeLookups.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _paymentTypeLookupRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.PaymentTypeLookups.Create)]
        public virtual async Task<PaymentTypeLookupDto> CreateAsync(PaymentTypeLookupCreateDto input)
        {

            var paymentTypeLookup = await _paymentTypeLookupManager.CreateAsync(
            input.Code, input.Name, input.Description
            );

            return ObjectMapper.Map<PaymentTypeLookup, PaymentTypeLookupDto>(paymentTypeLookup);
        }

        [Authorize(ApplicationPermissions.PaymentTypeLookups.Edit)]
        public virtual async Task<PaymentTypeLookupDto> UpdateAsync(int id, PaymentTypeLookupUpdateDto input)
        {

            var paymentTypeLookup = await _paymentTypeLookupManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PaymentTypeLookup, PaymentTypeLookupDto>(paymentTypeLookup);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentTypeLookupExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _paymentTypeLookupRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<PaymentTypeLookup>, List<PaymentTypeLookupExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PaymentTypeLookups.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new PaymentTypeLookupExcelDownloadTokenCacheItem { Token = token },
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