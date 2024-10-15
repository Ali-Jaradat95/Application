using Volo.Abp.Application.Dtos;
using System;

namespace Application.ApiRequestResponseLogs
{
    public abstract class GetApiRequestResponseLogsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? RequestUrl { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestHeaders { get; set; }
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }
        public int? ResponseStatusCodeMin { get; set; }
        public int? ResponseStatusCodeMax { get; set; }
        public string? ResponseHeaders { get; set; }
        public int? DurationMsMin { get; set; }
        public int? DurationMsMax { get; set; }
        public DateTime? CreatedAtMin { get; set; }
        public DateTime? CreatedAtMax { get; set; }
        public string? CorrelationId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserId { get; set; }
        public string? ErrorDetails { get; set; }
        public bool? IsSuccessful { get; set; }
        public string? SourceSystem { get; set; }

        public GetApiRequestResponseLogsInputBase()
        {

        }
    }
}