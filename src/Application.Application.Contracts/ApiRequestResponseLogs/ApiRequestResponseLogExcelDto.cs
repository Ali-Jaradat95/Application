using System;

namespace Application.ApiRequestResponseLogs
{
    public abstract class ApiRequestResponseLogExcelDtoBase
    {
        public string? RequestUrl { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestHeaders { get; set; }
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }
        public int? ResponseStatusCode { get; set; }
        public string? ResponseHeaders { get; set; }
        public int? DurationMs { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CorrelationId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserId { get; set; }
        public string? ErrorDetails { get; set; }
        public bool IsSuccessful { get; set; }
        public string? SourceSystem { get; set; }
    }
}