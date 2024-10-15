using Volo.Abp.Application.Dtos;
using System;

namespace Application.MadfoatcomRequests
{
    public abstract class GetMadfoatcomRequestsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public int? BillerCodeMin { get; set; }
        public int? BillerCodeMax { get; set; }
        public string? BillingNo { get; set; }
        public string? BillNo { get; set; }
        public string? ServiceType { get; set; }
        public string? PrepaidCat { get; set; }
        public decimal? DueAmtMin { get; set; }
        public decimal? DueAmtMax { get; set; }
        public string? ValidationCode { get; set; }
        public string? JOEBPPSTrx { get; set; }
        public string? BankTrxId { get; set; }
        public string? BankCode { get; set; }
        public string? PmtStatus { get; set; }
        public decimal? PaidAmtMin { get; set; }
        public decimal? PaidAmtMax { get; set; }
        public decimal? FeesAmtMin { get; set; }
        public decimal? FeesAmtMax { get; set; }
        public bool? FeesOnBiller { get; set; }
        public DateTime? ProcessDateMin { get; set; }
        public DateTime? ProcessDateMax { get; set; }
        public DateTime? StmtDateMin { get; set; }
        public DateTime? StmtDateMax { get; set; }
        public string? AccessChannel { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentType { get; set; }
        public decimal? AmountMin { get; set; }
        public decimal? AmountMax { get; set; }
        public int? SetBnkCodeMin { get; set; }
        public int? SetBnkCodeMax { get; set; }
        public string? AcctNo { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public GetMadfoatcomRequestsInputBase()
        {

        }
    }
}