using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.MadfoatcomResponses
{
    public abstract class MadfoatcomResponseBase : FullAuditedAggregateRoot<int>
    {
        public virtual int? BillerCode { get; set; }

        [CanBeNull]
        public virtual string? BillingNo { get; set; }

        [CanBeNull]
        public virtual string? BillNo { get; set; }

        [CanBeNull]
        public virtual string? DueAmt { get; set; }

        [CanBeNull]
        public virtual string? ValidationCode { get; set; }

        [CanBeNull]
        public virtual string? ServiceType { get; set; }

        [CanBeNull]
        public virtual string? PrepaidCat { get; set; }

        [CanBeNull]
        public virtual string? Amount { get; set; }

        public virtual int? SetBnkCode { get; set; }

        [CanBeNull]
        public virtual string? AcctNo { get; set; }

        [CanBeNull]
        public virtual string? TransferReason { get; set; }

        [CanBeNull]
        public virtual string? ReceivingCountry { get; set; }

        [CanBeNull]
        public virtual string? CustName { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        [CanBeNull]
        public virtual string? Phone { get; set; }

        public virtual int? RecCount { get; set; }

        [CanBeNull]
        public virtual string? BillStatus { get; set; }

        [CanBeNull]
        public virtual string? DueAmount { get; set; }

        public virtual DateTime? IssueDate { get; set; }

        public virtual DateTime? OpenDate { get; set; }

        public virtual DateTime? DueDate { get; set; }

        public virtual DateTime? ExpiryDate { get; set; }

        public virtual DateTime? CloseDate { get; set; }

        [CanBeNull]
        public virtual string? BillType { get; set; }

        public virtual bool AllowPart { get; set; }

        [CanBeNull]
        public virtual string? Upper { get; set; }

        [CanBeNull]
        public virtual string? Lower { get; set; }

        public virtual int? BillsCount { get; set; }

        [CanBeNull]
        public virtual string? JOEBPPSTrx { get; set; }

        public virtual DateTime? ProcessDate { get; set; }

        [CanBeNull]
        public virtual string? STMTDate { get; set; }

        protected MadfoatcomResponseBase()
        {

        }

        public MadfoatcomResponseBase(bool allowPart, int? billerCode = null, string? billingNo = null, string? billNo = null, string? dueAmt = null, string? validationCode = null, string? serviceType = null, string? prepaidCat = null, string? amount = null, int? setBnkCode = null, string? acctNo = null, string? transferReason = null, string? receivingCountry = null, string? custName = null, string? email = null, string? phone = null, int? recCount = null, string? billStatus = null, string? dueAmount = null, DateTime? issueDate = null, DateTime? openDate = null, DateTime? dueDate = null, DateTime? expiryDate = null, DateTime? closeDate = null, string? billType = null, string? upper = null, string? lower = null, int? billsCount = null, string? jOEBPPSTrx = null, DateTime? processDate = null, string? sTMTDate = null)
        {

            AllowPart = allowPart;
            BillerCode = billerCode;
            BillingNo = billingNo;
            BillNo = billNo;
            DueAmt = dueAmt;
            ValidationCode = validationCode;
            ServiceType = serviceType;
            PrepaidCat = prepaidCat;
            Amount = amount;
            SetBnkCode = setBnkCode;
            AcctNo = acctNo;
            TransferReason = transferReason;
            ReceivingCountry = receivingCountry;
            CustName = custName;
            Email = email;
            Phone = phone;
            RecCount = recCount;
            BillStatus = billStatus;
            DueAmount = dueAmount;
            IssueDate = issueDate;
            OpenDate = openDate;
            DueDate = dueDate;
            ExpiryDate = expiryDate;
            CloseDate = closeDate;
            BillType = billType;
            Upper = upper;
            Lower = lower;
            BillsCount = billsCount;
            JOEBPPSTrx = jOEBPPSTrx;
            ProcessDate = processDate;
            STMTDate = sTMTDate;
        }

    }
}