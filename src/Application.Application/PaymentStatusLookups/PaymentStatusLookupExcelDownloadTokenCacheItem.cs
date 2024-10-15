using System;

namespace Application.PaymentStatusLookups;

public abstract class PaymentStatusLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}