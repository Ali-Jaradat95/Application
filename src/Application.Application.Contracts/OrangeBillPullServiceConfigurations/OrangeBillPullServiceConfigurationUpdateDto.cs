using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Application.OrangeBillPullServiceConfigurations
{
    public abstract class OrangeBillPullServiceConfigurationUpdateDtoBase : IHasConcurrencyStamp
    {
        public int ServiceTypeId { get; set; }
        public bool IsServiceEnabled { get; set; }
        public bool IsWebServiceEnabled { get; set; }
        [Required]
        public string WebServiceUrl { get; set; } = null!;
        public string? StoredProcedureName { get; set; }
        public string? BillerCode { get; set; }
        public string? ConnectionStringUserId { get; set; }
        public string? ConnectionStringPassword { get; set; }
        public string? ConnectionStringDataSource { get; set; }
        public string? LogLevel { get; set; }
        public int? SeverityId { get; set; }
        public int? DailyLimit { get; set; }
        public int? WeeklyLimit { get; set; }
        public int? MonthlyLimit { get; set; }
        public int? YearlyLimit { get; set; }
        public string? ErrorMessage { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}