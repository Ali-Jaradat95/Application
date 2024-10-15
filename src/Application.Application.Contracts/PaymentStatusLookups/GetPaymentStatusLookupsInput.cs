using Volo.Abp.Application.Dtos;
using System;

namespace Application.PaymentStatusLookups
{
    public abstract class GetPaymentStatusLookupsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetPaymentStatusLookupsInputBase()
        {

        }
    }
}