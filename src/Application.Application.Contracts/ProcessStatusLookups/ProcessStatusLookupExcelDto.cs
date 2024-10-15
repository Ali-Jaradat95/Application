using System;

namespace Application.ProcessStatusLookups
{
    public abstract class ProcessStatusLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}