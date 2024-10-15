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

namespace Application.MadfoatcomRequests
{
    public abstract class EfCoreMadfoatcomRequestRepositoryBase : EfCoreRepository<ApplicationDbContext, MadfoatcomRequest, int>, IMadfoatcomRequestRepository
    {
        public EfCoreMadfoatcomRequestRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<MadfoatcomRequest>> GetListAsync(
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? serviceType = null,
            string? prepaidCat = null,
            decimal? dueAmtMin = null,
            decimal? dueAmtMax = null,
            string? validationCode = null,
            string? jOEBPPSTrx = null,
            string? bankTrxId = null,
            string? bankCode = null,
            string? pmtStatus = null,
            decimal? paidAmtMin = null,
            decimal? paidAmtMax = null,
            decimal? feesAmtMin = null,
            decimal? feesAmtMax = null,
            bool? feesOnBiller = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            DateTime? stmtDateMin = null,
            DateTime? stmtDateMax = null,
            string? accessChannel = null,
            string? paymentMethod = null,
            string? paymentType = null,
            decimal? amountMin = null,
            decimal? amountMax = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? name = null,
            string? phone = null,
            string? address = null,
            string? email = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, billerCodeMin, billerCodeMax, billingNo, billNo, serviceType, prepaidCat, dueAmtMin, dueAmtMax, validationCode, jOEBPPSTrx, bankTrxId, bankCode, pmtStatus, paidAmtMin, paidAmtMax, feesAmtMin, feesAmtMax, feesOnBiller, processDateMin, processDateMax, stmtDateMin, stmtDateMax, accessChannel, paymentMethod, paymentType, amountMin, amountMax, setBnkCodeMin, setBnkCodeMax, acctNo, name, phone, address, email);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MadfoatcomRequestConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? serviceType = null,
            string? prepaidCat = null,
            decimal? dueAmtMin = null,
            decimal? dueAmtMax = null,
            string? validationCode = null,
            string? jOEBPPSTrx = null,
            string? bankTrxId = null,
            string? bankCode = null,
            string? pmtStatus = null,
            decimal? paidAmtMin = null,
            decimal? paidAmtMax = null,
            decimal? feesAmtMin = null,
            decimal? feesAmtMax = null,
            bool? feesOnBiller = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            DateTime? stmtDateMin = null,
            DateTime? stmtDateMax = null,
            string? accessChannel = null,
            string? paymentMethod = null,
            string? paymentType = null,
            decimal? amountMin = null,
            decimal? amountMax = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? name = null,
            string? phone = null,
            string? address = null,
            string? email = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, billerCodeMin, billerCodeMax, billingNo, billNo, serviceType, prepaidCat, dueAmtMin, dueAmtMax, validationCode, jOEBPPSTrx, bankTrxId, bankCode, pmtStatus, paidAmtMin, paidAmtMax, feesAmtMin, feesAmtMax, feesOnBiller, processDateMin, processDateMax, stmtDateMin, stmtDateMax, accessChannel, paymentMethod, paymentType, amountMin, amountMax, setBnkCodeMin, setBnkCodeMax, acctNo, name, phone, address, email);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MadfoatcomRequest> ApplyFilter(
            IQueryable<MadfoatcomRequest> query,
            string? filterText = null,
            int? billerCodeMin = null,
            int? billerCodeMax = null,
            string? billingNo = null,
            string? billNo = null,
            string? serviceType = null,
            string? prepaidCat = null,
            decimal? dueAmtMin = null,
            decimal? dueAmtMax = null,
            string? validationCode = null,
            string? jOEBPPSTrx = null,
            string? bankTrxId = null,
            string? bankCode = null,
            string? pmtStatus = null,
            decimal? paidAmtMin = null,
            decimal? paidAmtMax = null,
            decimal? feesAmtMin = null,
            decimal? feesAmtMax = null,
            bool? feesOnBiller = null,
            DateTime? processDateMin = null,
            DateTime? processDateMax = null,
            DateTime? stmtDateMin = null,
            DateTime? stmtDateMax = null,
            string? accessChannel = null,
            string? paymentMethod = null,
            string? paymentType = null,
            decimal? amountMin = null,
            decimal? amountMax = null,
            int? setBnkCodeMin = null,
            int? setBnkCodeMax = null,
            string? acctNo = null,
            string? name = null,
            string? phone = null,
            string? address = null,
            string? email = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BillingNo!.Contains(filterText!) || e.BillNo!.Contains(filterText!) || e.ServiceType!.Contains(filterText!) || e.PrepaidCat!.Contains(filterText!) || e.ValidationCode!.Contains(filterText!) || e.JOEBPPSTrx!.Contains(filterText!) || e.BankTrxId!.Contains(filterText!) || e.BankCode!.Contains(filterText!) || e.PmtStatus!.Contains(filterText!) || e.AccessChannel!.Contains(filterText!) || e.PaymentMethod!.Contains(filterText!) || e.PaymentType!.Contains(filterText!) || e.AcctNo!.Contains(filterText!) || e.Name!.Contains(filterText!) || e.Phone!.Contains(filterText!) || e.Address!.Contains(filterText!) || e.Email!.Contains(filterText!))
                    .WhereIf(billerCodeMin.HasValue, e => e.BillerCode >= billerCodeMin!.Value)
                    .WhereIf(billerCodeMax.HasValue, e => e.BillerCode <= billerCodeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(billingNo), e => e.BillingNo.Contains(billingNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(billNo), e => e.BillNo.Contains(billNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceType), e => e.ServiceType.Contains(serviceType))
                    .WhereIf(!string.IsNullOrWhiteSpace(prepaidCat), e => e.PrepaidCat.Contains(prepaidCat))
                    .WhereIf(dueAmtMin.HasValue, e => e.DueAmt >= dueAmtMin!.Value)
                    .WhereIf(dueAmtMax.HasValue, e => e.DueAmt <= dueAmtMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(validationCode), e => e.ValidationCode.Contains(validationCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(jOEBPPSTrx), e => e.JOEBPPSTrx.Contains(jOEBPPSTrx))
                    .WhereIf(!string.IsNullOrWhiteSpace(bankTrxId), e => e.BankTrxId.Contains(bankTrxId))
                    .WhereIf(!string.IsNullOrWhiteSpace(bankCode), e => e.BankCode.Contains(bankCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(pmtStatus), e => e.PmtStatus.Contains(pmtStatus))
                    .WhereIf(paidAmtMin.HasValue, e => e.PaidAmt >= paidAmtMin!.Value)
                    .WhereIf(paidAmtMax.HasValue, e => e.PaidAmt <= paidAmtMax!.Value)
                    .WhereIf(feesAmtMin.HasValue, e => e.FeesAmt >= feesAmtMin!.Value)
                    .WhereIf(feesAmtMax.HasValue, e => e.FeesAmt <= feesAmtMax!.Value)
                    .WhereIf(feesOnBiller.HasValue, e => e.FeesOnBiller == feesOnBiller)
                    .WhereIf(processDateMin.HasValue, e => e.ProcessDate >= processDateMin!.Value)
                    .WhereIf(processDateMax.HasValue, e => e.ProcessDate <= processDateMax!.Value)
                    .WhereIf(stmtDateMin.HasValue, e => e.StmtDate >= stmtDateMin!.Value)
                    .WhereIf(stmtDateMax.HasValue, e => e.StmtDate <= stmtDateMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(accessChannel), e => e.AccessChannel.Contains(accessChannel))
                    .WhereIf(!string.IsNullOrWhiteSpace(paymentMethod), e => e.PaymentMethod.Contains(paymentMethod))
                    .WhereIf(!string.IsNullOrWhiteSpace(paymentType), e => e.PaymentType.Contains(paymentType))
                    .WhereIf(amountMin.HasValue, e => e.Amount >= amountMin!.Value)
                    .WhereIf(amountMax.HasValue, e => e.Amount <= amountMax!.Value)
                    .WhereIf(setBnkCodeMin.HasValue, e => e.SetBnkCode >= setBnkCodeMin!.Value)
                    .WhereIf(setBnkCodeMax.HasValue, e => e.SetBnkCode <= setBnkCodeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(acctNo), e => e.AcctNo.Contains(acctNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.Contains(phone))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email));
        }
    }
}