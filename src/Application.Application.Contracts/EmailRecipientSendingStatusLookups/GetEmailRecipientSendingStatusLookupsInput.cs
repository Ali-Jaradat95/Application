using Volo.Abp.Application.Dtos;
using System;

namespace Application.EmailRecipientSendingStatusLookups
{
    public abstract class GetEmailRecipientSendingStatusLookupsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetEmailRecipientSendingStatusLookupsInputBase()
        {

        }
    }
}