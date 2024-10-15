using System;

namespace Application.PaymentTypeLookups;

public abstract class PaymentTypeLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}