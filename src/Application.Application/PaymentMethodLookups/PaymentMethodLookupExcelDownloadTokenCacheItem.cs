using System;

namespace Application.PaymentMethodLookups;

public abstract class PaymentMethodLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}