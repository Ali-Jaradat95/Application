using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.MadfoatcomRequests
{
    public abstract class MadfoatcomRequestManagerBase : DomainService
    {
        protected IMadfoatcomRequestRepository _madfoatcomRequestRepository;

        public MadfoatcomRequestManagerBase(IMadfoatcomRequestRepository madfoatcomRequestRepository)
        {
            _madfoatcomRequestRepository = madfoatcomRequestRepository;
        }

        public virtual async Task<MadfoatcomRequest> CreateAsync(
        int billerCode, bool feesOnBiller, string? billingNo = null, string? billNo = null, string? serviceType = null, string? prepaidCat = null, decimal? dueAmt = null, string? validationCode = null, string? jOEBPPSTrx = null, string? bankTrxId = null, string? bankCode = null, string? pmtStatus = null, decimal? paidAmt = null, decimal? feesAmt = null, DateTime? processDate = null, DateTime? stmtDate = null, string? accessChannel = null, string? paymentMethod = null, string? paymentType = null, decimal? amount = null, int? setBnkCode = null, string? acctNo = null, string? name = null, string? phone = null, string? address = null, string? email = null)
        {

            var madfoatcomRequest = new MadfoatcomRequest(

             billerCode, feesOnBiller, billingNo, billNo, serviceType, prepaidCat, dueAmt, validationCode, jOEBPPSTrx, bankTrxId, bankCode, pmtStatus, paidAmt, feesAmt, processDate, stmtDate, accessChannel, paymentMethod, paymentType, amount, setBnkCode, acctNo, name, phone, address, email
             );

            return await _madfoatcomRequestRepository.InsertAsync(madfoatcomRequest);
        }

        public virtual async Task<MadfoatcomRequest> UpdateAsync(
            int id,
            int billerCode, bool feesOnBiller, string? billingNo = null, string? billNo = null, string? serviceType = null, string? prepaidCat = null, decimal? dueAmt = null, string? validationCode = null, string? jOEBPPSTrx = null, string? bankTrxId = null, string? bankCode = null, string? pmtStatus = null, decimal? paidAmt = null, decimal? feesAmt = null, DateTime? processDate = null, DateTime? stmtDate = null, string? accessChannel = null, string? paymentMethod = null, string? paymentType = null, decimal? amount = null, int? setBnkCode = null, string? acctNo = null, string? name = null, string? phone = null, string? address = null, string? email = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var madfoatcomRequest = await _madfoatcomRequestRepository.GetAsync(id);

            madfoatcomRequest.BillerCode = billerCode;
            madfoatcomRequest.FeesOnBiller = feesOnBiller;
            madfoatcomRequest.BillingNo = billingNo;
            madfoatcomRequest.BillNo = billNo;
            madfoatcomRequest.ServiceType = serviceType;
            madfoatcomRequest.PrepaidCat = prepaidCat;
            madfoatcomRequest.DueAmt = dueAmt;
            madfoatcomRequest.ValidationCode = validationCode;
            madfoatcomRequest.JOEBPPSTrx = jOEBPPSTrx;
            madfoatcomRequest.BankTrxId = bankTrxId;
            madfoatcomRequest.BankCode = bankCode;
            madfoatcomRequest.PmtStatus = pmtStatus;
            madfoatcomRequest.PaidAmt = paidAmt;
            madfoatcomRequest.FeesAmt = feesAmt;
            madfoatcomRequest.ProcessDate = processDate;
            madfoatcomRequest.StmtDate = stmtDate;
            madfoatcomRequest.AccessChannel = accessChannel;
            madfoatcomRequest.PaymentMethod = paymentMethod;
            madfoatcomRequest.PaymentType = paymentType;
            madfoatcomRequest.Amount = amount;
            madfoatcomRequest.SetBnkCode = setBnkCode;
            madfoatcomRequest.AcctNo = acctNo;
            madfoatcomRequest.Name = name;
            madfoatcomRequest.Phone = phone;
            madfoatcomRequest.Address = address;
            madfoatcomRequest.Email = email;

            madfoatcomRequest.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _madfoatcomRequestRepository.UpdateAsync(madfoatcomRequest);
        }

    }
}