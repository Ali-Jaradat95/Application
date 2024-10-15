using System;

namespace Application.PaymentSourceLookups;

public abstract class PaymentSourceLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}