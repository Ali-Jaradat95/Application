using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.MadfoatcomRequests
{
    public abstract class MadfoatcomRequestBase : FullAuditedAggregateRoot<int>
    {
        public virtual int BillerCode { get; set; }

        [CanBeNull]
        public virtual string? BillingNo { get; set; }

        [CanBeNull]
        public virtual string? BillNo { get; set; }

        [CanBeNull]
        public virtual string? ServiceType { get; set; }

        [CanBeNull]
        public virtual string? PrepaidCat { get; set; }

        public virtual decimal? DueAmt { get; set; }

        [CanBeNull]
        public virtual string? ValidationCode { get; set; }

        [CanBeNull]
        public virtual string? JOEBPPSTrx { get; set; }

        [CanBeNull]
        public virtual string? BankTrxId { get; set; }

        [CanBeNull]
        public virtual string? BankCode { get; set; }

        [CanBeNull]
        public virtual string? PmtStatus { get; set; }

        public virtual decimal? PaidAmt { get; set; }

        public virtual decimal? FeesAmt { get; set; }

        public virtual bool FeesOnBiller { get; set; }

        public virtual DateTime? ProcessDate { get; set; }

        public virtual DateTime? StmtDate { get; set; }

        [CanBeNull]
        public virtual string? AccessChannel { get; set; }

        [CanBeNull]
        public virtual string? PaymentMethod { get; set; }

        [CanBeNull]
        public virtual string? PaymentType { get; set; }

        public virtual decimal? Amount { get; set; }

        public virtual int? SetBnkCode { get; set; }

        [CanBeNull]
        public virtual string? AcctNo { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Phone { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        protected MadfoatcomRequestBase()
        {

        }

        public MadfoatcomRequestBase(int billerCode, bool feesOnBiller, string? billingNo = null, string? billNo = null, string? serviceType = null, string? prepaidCat = null, decimal? dueAmt = null, string? validationCode = null, string? jOEBPPSTrx = null, string? bankTrxId = null, string? bankCode = null, string? pmtStatus = null, decimal? paidAmt = null, decimal? feesAmt = null, DateTime? processDate = null, DateTime? stmtDate = null, string? accessChannel = null, string? paymentMethod = null, string? paymentType = null, decimal? amount = null, int? setBnkCode = null, string? acctNo = null, string? name = null, string? phone = null, string? address = null, string? email = null)
        {

            BillerCode = billerCode;
            FeesOnBiller = feesOnBiller;
            BillingNo = billingNo;
            BillNo = billNo;
            ServiceType = serviceType;
            PrepaidCat = prepaidCat;
            DueAmt = dueAmt;
            ValidationCode = validationCode;
            JOEBPPSTrx = jOEBPPSTrx;
            BankTrxId = bankTrxId;
            BankCode = bankCode;
            PmtStatus = pmtStatus;
            PaidAmt = paidAmt;
            FeesAmt = feesAmt;
            ProcessDate = processDate;
            StmtDate = stmtDate;
            AccessChannel = accessChannel;
            PaymentMethod = paymentMethod;
            PaymentType = paymentType;
            Amount = amount;
            SetBnkCode = setBnkCode;
            AcctNo = acctNo;
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
        }

    }
}