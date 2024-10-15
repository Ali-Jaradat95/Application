using System;

namespace Application.BillStatusLookups
{
    public abstract class BillStatusLookupExcelDtoBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}