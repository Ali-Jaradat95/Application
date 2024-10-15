using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Application.MadfoatcomResponses
{
    public abstract class MadfoatcomResponseUpdateDtoBase : IHasConcurrencyStamp
    {
        public int? BillerCode { get; set; }
        public string? BillingNo { get; set; }
        public string? BillNo { get; set; }
        public string? DueAmt { get; set; }
        public string? ValidationCode { get; set; }
        public string? ServiceType { get; set; }
        public string? PrepaidCat { get; set; }
        public string? Amount { get; set; }
        public int? SetBnkCode { get; set; }
        public string? AcctNo { get; set; }
        public string? TransferReason { get; set; }
        public string? ReceivingCountry { get; set; }
        public string? CustName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? RecCount { get; set; }
        public string? BillStatus { get; set; }
        public string? DueAmount { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? BillType { get; set; }
        public bool AllowPart { get; set; }
        public string? Upper { get; set; }
        public string? Lower { get; set; }
        public int? BillsCount { get; set; }
        public string? JOEBPPSTrx { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string? STMTDate { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}