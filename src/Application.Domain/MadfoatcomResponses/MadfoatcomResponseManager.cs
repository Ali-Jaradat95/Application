using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.MadfoatcomResponses
{
    public abstract class MadfoatcomResponseManagerBase : DomainService
    {
        protected IMadfoatcomResponseRepository _madfoatcomResponseRepository;

        public MadfoatcomResponseManagerBase(IMadfoatcomResponseRepository madfoatcomResponseRepository)
        {
            _madfoatcomResponseRepository = madfoatcomResponseRepository;
        }

        public virtual async Task<MadfoatcomResponse> CreateAsync(
        bool allowPart, int? billerCode = null, string? billingNo = null, string? billNo = null, string? dueAmt = null, string? validationCode = null, string? serviceType = null, string? prepaidCat = null, string? amount = null, int? setBnkCode = null, string? acctNo = null, string? transferReason = null, string? receivingCountry = null, string? custName = null, string? email = null, string? phone = null, int? recCount = null, string? billStatus = null, string? dueAmount = null, DateTime? issueDate = null, DateTime? openDate = null, DateTime? dueDate = null, DateTime? expiryDate = null, DateTime? closeDate = null, string? billType = null, string? upper = null, string? lower = null, int? billsCount = null, string? jOEBPPSTrx = null, DateTime? processDate = null, string? sTMTDate = null)
        {

            var madfoatcomResponse = new MadfoatcomResponse(

             allowPart, billerCode, billingNo, billNo, dueAmt, validationCode, serviceType, prepaidCat, amount, setBnkCode, acctNo, transferReason, receivingCountry, custName, email, phone, recCount, billStatus, dueAmount, issueDate, openDate, dueDate, expiryDate, closeDate, billType, upper, lower, billsCount, jOEBPPSTrx, processDate, sTMTDate
             );

            return await _madfoatcomResponseRepository.InsertAsync(madfoatcomResponse);
        }

        public virtual async Task<MadfoatcomResponse> UpdateAsync(
            int id,
            bool allowPart, int? billerCode = null, string? billingNo = null, string? billNo = null, string? dueAmt = null, string? validationCode = null, string? serviceType = null, string? prepaidCat = null, string? amount = null, int? setBnkCode = null, string? acctNo = null, string? transferReason = null, string? receivingCountry = null, string? custName = null, string? email = null, string? phone = null, int? recCount = null, string? billStatus = null, string? dueAmount = null, DateTime? issueDate = null, DateTime? openDate = null, DateTime? dueDate = null, DateTime? expiryDate = null, DateTime? closeDate = null, string? billType = null, string? upper = null, string? lower = null, int? billsCount = null, string? jOEBPPSTrx = null, DateTime? processDate = null, string? sTMTDate = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var madfoatcomResponse = await _madfoatcomResponseRepository.GetAsync(id);

            madfoatcomResponse.AllowPart = allowPart;
            madfoatcomResponse.BillerCode = billerCode;
            madfoatcomResponse.BillingNo = billingNo;
            madfoatcomResponse.BillNo = billNo;
            madfoatcomResponse.DueAmt = dueAmt;
            madfoatcomResponse.ValidationCode = validationCode;
            madfoatcomResponse.ServiceType = serviceType;
            madfoatcomResponse.PrepaidCat = prepaidCat;
            madfoatcomResponse.Amount = amount;
            madfoatcomResponse.SetBnkCode = setBnkCode;
            madfoatcomResponse.AcctNo = acctNo;
            madfoatcomResponse.TransferReason = transferReason;
            madfoatcomResponse.ReceivingCountry = receivingCountry;
            madfoatcomResponse.CustName = custName;
            madfoatcomResponse.Email = email;
            madfoatcomResponse.Phone = phone;
            madfoatcomResponse.RecCount = recCount;
            madfoatcomResponse.BillStatus = billStatus;
            madfoatcomResponse.DueAmount = dueAmount;
            madfoatcomResponse.IssueDate = issueDate;
            madfoatcomResponse.OpenDate = openDate;
            madfoatcomResponse.DueDate = dueDate;
            madfoatcomResponse.ExpiryDate = expiryDate;
            madfoatcomResponse.CloseDate = closeDate;
            madfoatcomResponse.BillType = billType;
            madfoatcomResponse.Upper = upper;
            madfoatcomResponse.Lower = lower;
            madfoatcomResponse.BillsCount = billsCount;
            madfoatcomResponse.JOEBPPSTrx = jOEBPPSTrx;
            madfoatcomResponse.ProcessDate = processDate;
            madfoatcomResponse.STMTDate = sTMTDate;

            madfoatcomResponse.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _madfoatcomResponseRepository.UpdateAsync(madfoatcomResponse);
        }

    }
}