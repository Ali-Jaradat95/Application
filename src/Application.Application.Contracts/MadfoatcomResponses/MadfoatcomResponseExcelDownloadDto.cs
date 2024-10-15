using Volo.Abp.Application.Dtos;
using System;

namespace Application.MadfoatcomResponses
{
    public abstract class MadfoatcomResponseExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? BillerCodeMin { get; set; }
        public int? BillerCodeMax { get; set; }
        public string? BillingNo { get; set; }
        public string? BillNo { get; set; }
        public string? DueAmt { get; set; }
        public string? ValidationCode { get; set; }
        public string? ServiceType { get; set; }
        public string? PrepaidCat { get; set; }
        public string? Amount { get; set; }
        public int? SetBnkCodeMin { get; set; }
        public int? SetBnkCodeMax { get; set; }
        public string? AcctNo { get; set; }
        public string? TransferReason { get; set; }
        public string? ReceivingCountry { get; set; }
        public string? CustName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? RecCountMin { get; set; }
        public int? RecCountMax { get; set; }
        public string? BillStatus { get; set; }
        public string? DueAmount { get; set; }
        public DateTime? IssueDateMin { get; set; }
        public DateTime? IssueDateMax { get; set; }
        public DateTime? OpenDateMin { get; set; }
        public DateTime? OpenDateMax { get; set; }
        public DateTime? DueDateMin { get; set; }
        public DateTime? DueDateMax { get; set; }
        public DateTime? ExpiryDateMin { get; set; }
        public DateTime? ExpiryDateMax { get; set; }
        public DateTime? CloseDateMin { get; set; }
        public DateTime? CloseDateMax { get; set; }
        public string? BillType { get; set; }
        public bool? AllowPart { get; set; }
        public string? Upper { get; set; }
        public string? Lower { get; set; }
        public int? BillsCountMin { get; set; }
        public int? BillsCountMax { get; set; }
        public string? JOEBPPSTrx { get; set; }
        public DateTime? ProcessDateMin { get; set; }
        public DateTime? ProcessDateMax { get; set; }
        public string? STMTDate { get; set; }

        public MadfoatcomResponseExcelDownloadDtoBase()
        {

        }
    }
}