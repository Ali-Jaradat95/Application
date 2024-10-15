using System;

namespace Application.BillStatusLookups;

public abstract class BillStatusLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}