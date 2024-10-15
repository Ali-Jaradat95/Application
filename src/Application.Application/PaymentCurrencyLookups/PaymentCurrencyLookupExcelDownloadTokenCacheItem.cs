using System;

namespace Application.PaymentCurrencyLookups;

public abstract class PaymentCurrencyLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}