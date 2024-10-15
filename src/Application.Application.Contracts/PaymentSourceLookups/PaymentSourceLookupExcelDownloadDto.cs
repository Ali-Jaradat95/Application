using Volo.Abp.Application.Dtos;
using System;

namespace Application.PaymentSourceLookups
{
    public abstract class PaymentSourceLookupExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public PaymentSourceLookupExcelDownloadDtoBase()
        {

        }
    }
}