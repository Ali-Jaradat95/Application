using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Application.EntityFrameworkCore;

namespace Application.MadfoatcomResponses
{
    public abstract class EfCoreMadfoatcomResponseRepositoryBase : EfCoreRepository<ApplicationDbContext, MadfoatcomResponse, int>, IMadfoatcomResponseRepository
    {
        public EfCoreMadfoatcomResponseRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<MadfoatcomResponse>> GetListAsync(
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? dueAmt = null,
            string? validationCode = null,
            string? serviceType = null,
            string? prepaidCat = null,
            string? amount = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? transferReason = null,
            string? receivingCountry = null,
            string? custName = null,
            string? email = null,
            string? phone = null,
            int? recCountMin = null,
            int? recCountMax = null,
            string? billStatus = null,
            string? dueAmount = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? openDateMin = null,
            DateTime? openDateMax = null,
            DateTime? dueDateMin = null,
            DateTime? dueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            string? billType = null,
            bool? allowPart = null,
            string? upper = null,
            string? lower = null,
            int? billsCountMin = null,
            int? billsCountMax = null,
            string? jOEBPPSTrx = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            string? sTMTDate = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, billerCodeMin, billerCodeMax, billingNo, billNo, dueAmt, validationCode, serviceType, prepaidCat, amount, setBnkCodeMin, setBnkCodeMax, acctNo, transferReason, receivingCountry, custName, email, phone, recCountMin, recCountMax, billStatus, dueAmount, issueDateMin, issueDateMax, openDateMin, openDateMax, dueDateMin, dueDateMax, expiryDateMin, expiryDateMax, closeDateMin, closeDateMax, billType, allowPart, upper, lower, billsCountMin, billsCountMax, jOEBPPSTrx, processDateMin, processDateMax, sTMTDate);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MadfoatcomResponseConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? dueAmt = null,
            string? validationCode = null,
            string? serviceType = null,
            string? prepaidCat = null,
            string? amount = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? transferReason = null,
            string? receivingCountry = null,
            string? custName = null,
            string? email = null,
            string? phone = null,
            int? recCountMin = null,
            int? recCountMax = null,
            string? billStatus = null,
            string? dueAmount = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? openDateMin = null,
            DateTime? openDateMax = null,
            DateTime? dueDateMin = null,
            DateTime? dueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            string? billType = null,
            bool? allowPart = null,
            string? upper = null,
            string? lower = null,
            int? billsCountMin = null,
            int? billsCountMax = null,
            string? jOEBPPSTrx = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            string? sTMTDate = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, billerCodeMin, billerCodeMax, billingNo, billNo, dueAmt, validationCode, serviceType, prepaidCat, amount, setBnkCodeMin, setBnkCodeMax, acctNo, transferReason, receivingCountry, custName, email, phone, recCountMin, recCountMax, billStatus, dueAmount, issueDateMin, issueDateMax, openDateMin, openDateMax, dueDateMin, dueDateMax, expiryDateMin, expiryDateMax, closeDateMin, closeDateMax, billType, allowPart, upper, lower, billsCountMin, billsCountMax, jOEBPPSTrx, processDateMin, processDateMax, sTMTDate);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MadfoatcomResponse> ApplyFilter(
            IQueryable<MadfoatcomResponse> query,
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? dueAmt = null,
            string? validationCode = null,
            string? serviceType = null,
            string? prepaidCat = null,
            string? amount = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? transferReason = null,
            string? receivingCountry = null,
            string? custName = null,
            string? email = null,
            string? phone = null,
            int? recCountMin = null,
            int? recCountMax = null,
            string? billStatus = null,
            string? dueAmount = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? openDateMin = null,
            DateTime? openDateMax = null,
            DateTime? dueDateMin = null,
            DateTime? dueDateMax = null,
            DateTime? expiryDateMin = null,
            DateTime? expiryDateMax = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            string? billType = null,
            bool? allowPart = null,
            string? upper = null,
            string? lower = null,
            int? billsCountMin = null,
            int? billsCountMax = null,
            string? jOEBPPSTrx = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            string? sTMTDate = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BillingNo!.Contains(filterText!) || e.BillNo!.Contains(filterText!) || e.DueAmt!.Contains(filterText!) || e.ValidationCode!.Contains(filterText!) || e.ServiceType!.Contains(filterText!) || e.PrepaidCat!.Contains(filterText!) || e.Amount!.Contains(filterText!) || e.AcctNo!.Contains(filterText!) || e.TransferReason!.Contains(filterText!) || e.ReceivingCountry!.Contains(filterText!) || e.CustName!.Contains(filterText!) || e.Email!.Contains(filterText!) || e.Phone!.Contains(filterText!) || e.BillStatus!.Contains(filterText!) || e.DueAmount!.Contains(filterText!) || e.BillType!.Contains(filterText!) || e.Upper!.Contains(filterText!) || e.Lower!.Contains(filterText!) || e.JOEBPPSTrx!.Contains(filterText!) || e.STMTDate!.Contains(filterText!))
                    .WhereIf(billerCodeMin.HasValue, e => e.BillerCode >= billerCodeMin!.Value)
                    .WhereIf(billerCodeMax.HasValue, e => e.BillerCode <= billerCodeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(billingNo), e => e.BillingNo.Contains(billingNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(billNo), e => e.BillNo.Contains(billNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(dueAmt), e => e.DueAmt.Contains(dueAmt))
                    .WhereIf(!string.IsNullOrWhiteSpace(validationCode), e => e.ValidationCode.Contains(validationCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceType), e => e.ServiceType.Contains(serviceType))
                    .WhereIf(!string.IsNullOrWhiteSpace(prepaidCat), e => e.PrepaidCat.Contains(prepaidCat))
                    .WhereIf(!string.IsNullOrWhiteSpace(amount), e => e.Amount.Contains(amount))
                    .WhereIf(setBnkCodeMin.HasValue, e => e.SetBnkCode >= setBnkCodeMin!.Value)
                    .WhereIf(setBnkCodeMax.HasValue, e => e.SetBnkCode <= setBnkCodeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(acctNo), e => e.AcctNo.Contains(acctNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(transferReason), e => e.TransferReason.Contains(transferReason))
                    .WhereIf(!string.IsNullOrWhiteSpace(receivingCountry), e => e.ReceivingCountry.Contains(receivingCountry))
                    .WhereIf(!string.IsNullOrWhiteSpace(custName), e => e.CustName.Contains(custName))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.Contains(phone))
                    .WhereIf(recCountMin.HasValue, e => e.RecCount >= recCountMin!.Value)
                    .WhereIf(recCountMax.HasValue, e => e.RecCount <= recCountMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(billStatus), e => e.BillStatus.Contains(billStatus))
                    .WhereIf(!string.IsNullOrWhiteSpace(dueAmount), e => e.DueAmount.Contains(dueAmount))
                    .WhereIf(issueDateMin.HasValue, e => e.IssueDate >= issueDateMin!.Value)
                    .WhereIf(issueDateMax.HasValue, e => e.IssueDate <= issueDateMax!.Value)
                    .WhereIf(openDateMin.HasValue, e => e.OpenDate >= openDateMin!.Value)
                    .WhereIf(openDateMax.HasValue, e => e.OpenDate <= openDateMax!.Value)
                    .WhereIf(dueDateMin.HasValue, e => e.DueDate >= dueDateMin!.Value)
                    .WhereIf(dueDateMax.HasValue, e => e.DueDate <= dueDateMax!.Value)
                    .WhereIf(expiryDateMin.HasValue, e => e.ExpiryDate >= expiryDateMin!.Value)
                    .WhereIf(expiryDateMax.HasValue, e => e.ExpiryDate <= expiryDateMax!.Value)
                    .WhereIf(closeDateMin.HasValue, e => e.CloseDate >= closeDateMin!.Value)
                    .WhereIf(closeDateMax.HasValue, e => e.CloseDate <= closeDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(billType), e => e.BillType.Contains(billType))
                    .WhereIf(allowPart.HasValue, e => e.AllowPart == allowPart)
                    .WhereIf(!string.IsNullOrWhiteSpace(upper), e => e.Upper.Contains(upper))
                    .WhereIf(!string.IsNullOrWhiteSpace(lower), e => e.Lower.Contains(lower))
                    .WhereIf(billsCountMin.HasValue, e => e.BillsCount >= billsCountMin!.Value)
                    .WhereIf(billsCountMax.HasValue, e => e.BillsCount <= billsCountMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(jOEBPPSTrx), e => e.JOEBPPSTrx.Contains(jOEBPPSTrx))
                    .WhereIf(processDateMin.HasValue, e => e.ProcessDate >= processDateMin!.Value)
                    .WhereIf(processDateMax.HasValue, e => e.ProcessDate <= processDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(sTMTDate), e => e.STMTDate.Contains(sTMTDate));
        }
    }
}