using System;

namespace Application.BillingStatusLookups;

public abstract class BillingStatusLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}