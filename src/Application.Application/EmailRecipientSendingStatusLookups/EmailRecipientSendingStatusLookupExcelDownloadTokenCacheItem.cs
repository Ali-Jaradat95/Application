using System;

namespace Application.EmailRecipientSendingStatusLookups;

public abstract class EmailRecipientSendingStatusLookupExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}