using System;

namespace Application.EmailRecipientSendingStatusLookups
{
    public abstract class EmailRecipientSendingStatusLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}