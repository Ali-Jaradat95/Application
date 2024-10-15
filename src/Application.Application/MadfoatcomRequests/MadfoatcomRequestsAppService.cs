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
using Application.MadfoatcomRequests;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.MadfoatcomRequests
{

    [Authorize(ApplicationPermissions.MadfoatcomRequests.Default)]
    public abstract class MadfoatcomRequestsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MadfoatcomRequestExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IMadfoatcomRequestRepository _madfoatcomRequestRepository;
        protected MadfoatcomRequestManager _madfoatcomRequestManager;

        public MadfoatcomRequestsAppServiceBase(IMadfoatcomRequestRepository madfoatcomRequestRepository, MadfoatcomRequestManager madfoatcomRequestManager, IDistributedCache<MadfoatcomRequestExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _madfoatcomRequestRepository = madfoatcomRequestRepository;
            _madfoatcomRequestManager = madfoatcomRequestManager;
        }

        public virtual async Task<PagedResultDto<MadfoatcomRequestDto>> GetListAsync(GetMadfoatcomRequestsInput input)
        {
            var totalCount = await _madfoatcomRequestRepository.GetCountAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.ServiceType, input.PrepaidCat, input.DueAmtMin, input.DueAmtMax, input.ValidationCode, input.JOEBPPSTrx, input.BankTrxId, input.BankCode, input.PmtStatus, input.PaidAmtMin, input.PaidAmtMax, input.FeesAmtMin, input.FeesAmtMax, input.FeesOnBiller, input.ProcessDateMin, input.ProcessDateMax, input.StmtDateMin, input.StmtDateMax, input.AccessChannel, input.PaymentMethod, input.PaymentType, input.AmountMin, input.AmountMax, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.Name, input.Phone, input.Address, input.Email);
            var items = await _madfoatcomRequestRepository.GetListAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.ServiceType, input.PrepaidCat, input.DueAmtMin, input.DueAmtMax, input.ValidationCode, input.JOEBPPSTrx, input.BankTrxId, input.BankCode, input.PmtStatus, input.PaidAmtMin, input.PaidAmtMax, input.FeesAmtMin, input.FeesAmtMax, input.FeesOnBiller, input.ProcessDateMin, input.ProcessDateMax, input.StmtDateMin, input.StmtDateMax, input.AccessChannel, input.PaymentMethod, input.PaymentType, input.AmountMin, input.AmountMax, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.Name, input.Phone, input.Address, input.Email, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MadfoatcomRequestDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MadfoatcomRequest>, List<MadfoatcomRequestDto>>(items)
            };
        }

        public virtual async Task<MadfoatcomRequestDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MadfoatcomRequest, MadfoatcomRequestDto>(await _madfoatcomRequestRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.MadfoatcomRequests.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _madfoatcomRequestRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.MadfoatcomRequests.Create)]
        public virtual async Task<MadfoatcomRequestDto> CreateAsync(MadfoatcomRequestCreateDto input)
        {

            var madfoatcomRequest = await _madfoatcomRequestManager.CreateAsync(
            input.BillerCode, input.FeesOnBiller, input.BillingNo, input.BillNo, input.ServiceType, input.PrepaidCat, input.DueAmt, input.ValidationCode, input.JOEBPPSTrx, input.BankTrxId, input.BankCode, input.PmtStatus, input.PaidAmt, input.FeesAmt, input.ProcessDate, input.StmtDate, input.AccessChannel, input.PaymentMethod, input.PaymentType, input.Amount, input.SetBnkCode, input.AcctNo, input.Name, input.Phone, input.Address, input.Email
            );

            return ObjectMapper.Map<MadfoatcomRequest, MadfoatcomRequestDto>(madfoatcomRequest);
        }

        [Authorize(ApplicationPermissions.MadfoatcomRequests.Edit)]
        public virtual async Task<MadfoatcomRequestDto> UpdateAsync(int id, MadfoatcomRequestUpdateDto input)
        {

            var madfoatcomRequest = await _madfoatcomRequestManager.UpdateAsync(
            id,
            input.BillerCode, input.FeesOnBiller, input.BillingNo, input.BillNo, input.ServiceType, input.PrepaidCat, input.DueAmt, input.ValidationCode, input.JOEBPPSTrx, input.BankTrxId, input.BankCode, input.PmtStatus, input.PaidAmt, input.FeesAmt, input.ProcessDate, input.StmtDate, input.AccessChannel, input.PaymentMethod, input.PaymentType, input.Amount, input.SetBnkCode, input.AcctNo, input.Name, input.Phone, input.Address, input.Email, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MadfoatcomRequest, MadfoatcomRequestDto>(madfoatcomRequest);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MadfoatcomRequestExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _madfoatcomRequestRepository.GetListAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.ServiceType, input.PrepaidCat, input.DueAmtMin, input.DueAmtMax, input.ValidationCode, input.JOEBPPSTrx, input.BankTrxId, input.BankCode, input.PmtStatus, input.PaidAmtMin, input.PaidAmtMax, input.FeesAmtMin, input.FeesAmtMax, input.FeesOnBiller, input.ProcessDateMin, input.ProcessDateMax, input.StmtDateMin, input.StmtDateMax, input.AccessChannel, input.PaymentMethod, input.PaymentType, input.AmountMin, input.AmountMax, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.Name, input.Phone, input.Address, input.Email);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MadfoatcomRequest>, List<MadfoatcomRequestExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MadfoatcomRequests.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MadfoatcomRequestExcelDownloadTokenCacheItem { Token = token },
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