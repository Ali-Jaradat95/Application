using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.MadfoatcomRequests
{
    public partial interface IMadfoatcomRequestRepository : IRepository<MadfoatcomRequest, int>
    {
        Task<List<MadfoatcomRequest>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}