using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Application.MadfoatcomRequests
{
    public abstract class MadfoatcomRequestDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public int BillerCode { get; set; }
        public string? BillingNo { get; set; }
        public string? BillNo { get; set; }
        public string? ServiceType { get; set; }
        public string? PrepaidCat { get; set; }
        public decimal? DueAmt { get; set; }
        public string? ValidationCode { get; set; }
        public string? JOEBPPSTrx { get; set; }
        public string? BankTrxId { get; set; }
        public string? BankCode { get; set; }
        public string? PmtStatus { get; set; }
        public decimal? PaidAmt { get; set; }
        public decimal? FeesAmt { get; set; }
        public bool FeesOnBiller { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? StmtDate { get; set; }
        public string? AccessChannel { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentType { get; set; }
        public decimal? Amount { get; set; }
        public int? SetBnkCode { get; set; }
        public string? AcctNo { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}