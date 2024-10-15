using System;

namespace Application.MessageEncodingLookups
{
    public abstract class MessageEncodingLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}