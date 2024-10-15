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
using Application.MadfoatcomResponses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.MadfoatcomResponses
{

    [Authorize(ApplicationPermissions.MadfoatcomResponses.Default)]
    public abstract class MadfoatcomResponsesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MadfoatcomResponseExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IMadfoatcomResponseRepository _madfoatcomResponseRepository;
        protected MadfoatcomResponseManager _madfoatcomResponseManager;

        public MadfoatcomResponsesAppServiceBase(IMadfoatcomResponseRepository madfoatcomResponseRepository, MadfoatcomResponseManager madfoatcomResponseManager, IDistributedCache<MadfoatcomResponseExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _madfoatcomResponseRepository = madfoatcomResponseRepository;
            _madfoatcomResponseManager = madfoatcomResponseManager;
        }

        public virtual async Task<PagedResultDto<MadfoatcomResponseDto>> GetListAsync(GetMadfoatcomResponsesInput input)
        {
            var totalCount = await _madfoatcomResponseRepository.GetCountAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.DueAmt, input.ValidationCode, input.ServiceType, input.PrepaidCat, input.Amount, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.TransferReason, input.ReceivingCountry, input.CustName, input.Email, input.Phone, input.RecCountMin, input.RecCountMax, input.BillStatus, input.DueAmount, input.IssueDateMin, input.IssueDateMax, input.OpenDateMin, input.OpenDateMax, input.DueDateMin, input.DueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.CloseDateMin, input.CloseDateMax, input.BillType, input.AllowPart, input.Upper, input.Lower, input.BillsCountMin, input.BillsCountMax, input.JOEBPPSTrx, input.ProcessDateMin, input.ProcessDateMax, input.STMTDate);
            var items = await _madfoatcomResponseRepository.GetListAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.DueAmt, input.ValidationCode, input.ServiceType, input.PrepaidCat, input.Amount, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.TransferReason, input.ReceivingCountry, input.CustName, input.Email, input.Phone, input.RecCountMin, input.RecCountMax, input.BillStatus, input.DueAmount, input.IssueDateMin, input.IssueDateMax, input.OpenDateMin, input.OpenDateMax, input.DueDateMin, input.DueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.CloseDateMin, input.CloseDateMax, input.BillType, input.AllowPart, input.Upper, input.Lower, input.BillsCountMin, input.BillsCountMax, input.JOEBPPSTrx, input.ProcessDateMin, input.ProcessDateMax, input.STMTDate, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MadfoatcomResponseDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MadfoatcomResponse>, List<MadfoatcomResponseDto>>(items)
            };
        }

        public virtual async Task<MadfoatcomResponseDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MadfoatcomResponse, MadfoatcomResponseDto>(await _madfoatcomResponseRepository.GetAsync(id));
        }

        [Authorize(ApplicationPermissions.MadfoatcomResponses.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _madfoatcomResponseRepository.DeleteAsync(id);
        }

        [Authorize(ApplicationPermissions.MadfoatcomResponses.Create)]
        public virtual async Task<MadfoatcomResponseDto> CreateAsync(MadfoatcomResponseCreateDto input)
        {

            var madfoatcomResponse = await _madfoatcomResponseManager.CreateAsync(
            input.AllowPart, input.BillerCode, input.BillingNo, input.BillNo, input.DueAmt, input.ValidationCode, input.ServiceType, input.PrepaidCat, input.Amount, input.SetBnkCode, input.AcctNo, input.TransferReason, input.ReceivingCountry, input.CustName, input.Email, input.Phone, input.RecCount, input.BillStatus, input.DueAmount, input.IssueDate, input.OpenDate, input.DueDate, input.ExpiryDate, input.CloseDate, input.BillType, input.Upper, input.Lower, input.BillsCount, input.JOEBPPSTrx, input.ProcessDate, input.STMTDate
            );

            return ObjectMapper.Map<MadfoatcomResponse, MadfoatcomResponseDto>(madfoatcomResponse);
        }

        [Authorize(ApplicationPermissions.MadfoatcomResponses.Edit)]
        public virtual async Task<MadfoatcomResponseDto> UpdateAsync(int id, MadfoatcomResponseUpdateDto input)
        {

            var madfoatcomResponse = await _madfoatcomResponseManager.UpdateAsync(
            id,
            input.AllowPart, input.BillerCode, input.BillingNo, input.BillNo, input.DueAmt, input.ValidationCode, input.ServiceType, input.PrepaidCat, input.Amount, input.SetBnkCode, input.AcctNo, input.TransferReason, input.ReceivingCountry, input.CustName, input.Email, input.Phone, input.RecCount, input.BillStatus, input.DueAmount, input.IssueDate, input.OpenDate, input.DueDate, input.ExpiryDate, input.CloseDate, input.BillType, input.Upper, input.Lower, input.BillsCount, input.JOEBPPSTrx, input.ProcessDate, input.STMTDate, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MadfoatcomResponse, MadfoatcomResponseDto>(madfoatcomResponse);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MadfoatcomResponseExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _madfoatcomResponseRepository.GetListAsync(input.FilterText, input.BillerCodeMin, input.BillerCodeMax, input.BillingNo, input.BillNo, input.DueAmt, input.ValidationCode, input.ServiceType, input.PrepaidCat, input.Amount, input.SetBnkCodeMin, input.SetBnkCodeMax, input.AcctNo, input.TransferReason, input.ReceivingCountry, input.CustName, input.Email, input.Phone, input.RecCountMin, input.RecCountMax, input.BillStatus, input.DueAmount, input.IssueDateMin, input.IssueDateMax, input.OpenDateMin, input.OpenDateMax, input.DueDateMin, input.DueDateMax, input.ExpiryDateMin, input.ExpiryDateMax, input.CloseDateMin, input.CloseDateMax, input.BillType, input.AllowPart, input.Upper, input.Lower, input.BillsCountMin, input.BillsCountMax, input.JOEBPPSTrx, input.ProcessDateMin, input.ProcessDateMax, input.STMTDate);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MadfoatcomResponse>, List<MadfoatcomResponseExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MadfoatcomResponses.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MadfoatcomResponseExcelDownloadTokenCacheItem { Token = token },
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