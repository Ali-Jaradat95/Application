using System;

namespace Application.BillTypeLookups;

public abstract class BillTypeLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}