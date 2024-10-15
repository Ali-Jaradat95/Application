using Volo.Abp.Application.Dtos;
using System;

namespace Application.OrangeBillPullServiceConfigurations
{
    public abstract class OrangeBillPullServiceConfigurationExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? ServiceTypeIdMin { get; set; }
        public int? ServiceTypeIdMax { get; set; }
        public bool? IsServiceEnabled { get; set; }
        public bool? IsWebServiceEnabled { get; set; }
        public string? WebServiceUrl { get; set; }
        public string? StoredProcedureName { get; set; }
        public string? BillerCode { get; set; }
        public string? ConnectionStringUserId { get; set; }
        public string? ConnectionStringPassword { get; set; }
        public string? ConnectionStringDataSource { get; set; }
        public string? LogLevel { get; set; }
        public int? SeverityIdMin { get; set; }
        public int? SeverityIdMax { get; set; }
        public int? DailyLimitMin { get; set; }
        public int? DailyLimitMax { get; set; }
        public int? WeeklyLimitMin { get; set; }
        public int? WeeklyLimitMax { get; set; }
        public int? MonthlyLimitMin { get; set; }
        public int? MonthlyLimitMax { get; set; }
        public int? YearlyLimitMin { get; set; }
        public int? YearlyLimitMax { get; set; }
        public string? ErrorMessage { get; set; }

        public OrangeBillPullServiceConfigurationExcelDownloadDtoBase()
        {

        }
    }
}