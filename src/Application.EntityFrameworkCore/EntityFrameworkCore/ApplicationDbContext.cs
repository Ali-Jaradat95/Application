using Application.PrepaidValidationConfigs;
using Application.OrangeBillPullServiceConfigurations;
using Application.OrangeBillPaymentNotificationConfigurations;
using Application.MadfoatcomResponses;
using Application.MadfoatcomRequests;
using Application.ApiRequestResponseLogs;
using Application.ThresholdLookups;
using Application.SeverityLookups;
using Application.ServiceTypeLookups;
using Application.ProcessStatusLookups;
using Application.PrepaidCategoryLookups;
using Application.PaymentTypeLookups;
using Application.PaymentStatusLookups;
using Application.PaymentSourceLookups;
using Application.PaymentMethodLookups;
using Application.PaymentCurrencyLookups;
using Application.OperationTypeLookups;
using Application.MethodTypeLookups;
using Application.MessageEncodingLookups;
using Application.LanguageIsoNameLookups;
using Application.EmailRecipientSendingStatusLookups;
using Application.CharSetLookups;
using Application.BillTypeLookups;
using Application.BillStatusLookups;
using Application.BillingStatusLookups;
using Application.AccessChannelLookups;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Application.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class ApplicationDbContext : ApplicationDbContextBase<ApplicationDbContext>
{
    public DbSet<PrepaidValidationConfig> PrepaidValidationConfigs { get; set; } = null!;
    public DbSet<OrangeBillPullServiceConfiguration> OrangeBillPullServiceConfigurations { get; set; } = null!;
    public DbSet<OrangeBillPaymentNotificationConfiguration> OrangeBillPaymentNotificationConfigurations { get; set; } = null!;
    public DbSet<MadfoatcomResponse> MadfoatcomResponses { get; set; } = null!;
    public DbSet<MadfoatcomRequest> MadfoatcomRequests { get; set; } = null!;
    public DbSet<ApiRequestResponseLog> ApiRequestResponseLogs { get; set; } = null!;
    public DbSet<ThresholdLookup> ThresholdLookups { get; set; } = null!;
    public DbSet<SeverityLookup> SeverityLookups { get; set; } = null!;
    public DbSet<ServiceTypeLookup> ServiceTypeLookups { get; set; } = null!;
    public DbSet<ProcessStatusLookup> ProcessStatusLookups { get; set; } = null!;
    public DbSet<PrepaidCategoryLookup> PrepaidCategoryLookups { get; set; } = null!;
    public DbSet<PaymentTypeLookup> PaymentTypeLookups { get; set; } = null!;
    public DbSet<PaymentStatusLookup> PaymentStatusLookups { get; set; } = null!;
    public DbSet<PaymentSourceLookup> PaymentSourceLookups { get; set; } = null!;
    public DbSet<PaymentMethodLookup> PaymentMethodLookups { get; set; } = null!;
    public DbSet<PaymentCurrencyLookup> PaymentCurrencyLookups { get; set; } = null!;
    public DbSet<OperationTypeLookup> OperationTypeLookups { get; set; } = null!;
    public DbSet<MethodTypeLookup> MethodTypeLookups { get; set; } = null!;
    public DbSet<MessageEncodingLookup> MessageEncodingLookups { get; set; } = null!;
    public DbSet<LanguageIsoNameLookup> LanguageIsoNameLookups { get; set; } = null!;
    public DbSet<EmailRecipientSendingStatusLookup> EmailRecipientSendingStatusLookups { get; set; } = null!;
    public DbSet<CharSetLookup> CharSetLookups { get; set; } = null!;
    public DbSet<BillTypeLookup> BillTypeLookups { get; set; } = null!;
    public DbSet<BillStatusLookup> BillStatusLookups { get; set; } = null!;
    public DbSet<BillingStatusLookup> BillingStatusLookups { get; set; } = null!;
    public DbSet<AccessChannelLookup> AccessChannelLookups { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetMultiTenancySide(MultiTenancySides.Both);

        base.OnModelCreating(builder);
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<CharSetLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "CharSetLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(CharSetLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(CharSetLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(CharSetLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<AccessChannelLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "AccessChannelLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(AccessChannelLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(AccessChannelLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(AccessChannelLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<BillingStatusLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "BillingStatusLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(BillingStatusLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(BillingStatusLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(BillingStatusLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<BillStatusLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "BillStatusLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(BillStatusLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(BillStatusLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(BillStatusLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<BillTypeLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "BillTypeLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(BillTypeLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(BillTypeLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(BillTypeLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<EmailRecipientSendingStatusLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "EmailRecipientSendingStatusLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(EmailRecipientSendingStatusLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(EmailRecipientSendingStatusLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(EmailRecipientSendingStatusLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<LanguageIsoNameLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "LanguageIsoNameLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(LanguageIsoNameLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(LanguageIsoNameLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(LanguageIsoNameLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<MessageEncodingLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "MessageEncodingLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(MessageEncodingLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(MessageEncodingLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(MessageEncodingLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<MethodTypeLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "MethodTypeLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(MethodTypeLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(MethodTypeLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(MethodTypeLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<OperationTypeLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "OperationTypeLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(OperationTypeLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(OperationTypeLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(OperationTypeLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentCurrencyLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PaymentCurrencyLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PaymentCurrencyLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PaymentCurrencyLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PaymentCurrencyLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentMethodLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PaymentMethodLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PaymentMethodLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PaymentMethodLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PaymentMethodLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentSourceLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PaymentSourceLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PaymentSourceLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PaymentSourceLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PaymentSourceLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentStatusLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PaymentStatusLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PaymentStatusLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PaymentStatusLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PaymentStatusLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PaymentTypeLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PaymentTypeLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PaymentTypeLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PaymentTypeLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PaymentTypeLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PrepaidCategoryLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PrepaidCategoryLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(PrepaidCategoryLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(PrepaidCategoryLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(PrepaidCategoryLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ProcessStatusLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "ProcessStatusLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(ProcessStatusLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(ProcessStatusLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(ProcessStatusLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ServiceTypeLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "ServiceTypeLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(ServiceTypeLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(ServiceTypeLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(ServiceTypeLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<SeverityLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "SeverityLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(SeverityLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(SeverityLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(SeverityLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ThresholdLookup>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "ThresholdLookup", "Lookups");
    b.ConfigureByConvention();
    b.Property(x => x.Code).HasColumnName(nameof(ThresholdLookup.Code)).IsRequired();
    b.Property(x => x.Name).HasColumnName(nameof(ThresholdLookup.Name)).IsRequired();
    b.Property(x => x.Description).HasColumnName(nameof(ThresholdLookup.Description));
});

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<MadfoatcomRequest>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "MadfoatcomRequest", "Madfoatcom");
    b.ConfigureByConvention();
    b.Property(x => x.BillerCode).HasColumnName(nameof(MadfoatcomRequest.BillerCode));
    b.Property(x => x.BillingNo).HasColumnName(nameof(MadfoatcomRequest.BillingNo));
    b.Property(x => x.BillNo).HasColumnName(nameof(MadfoatcomRequest.BillNo));
    b.Property(x => x.ServiceType).HasColumnName(nameof(MadfoatcomRequest.ServiceType));
    b.Property(x => x.PrepaidCat).HasColumnName(nameof(MadfoatcomRequest.PrepaidCat));
    b.Property(x => x.DueAmt).HasColumnName(nameof(MadfoatcomRequest.DueAmt));
    b.Property(x => x.ValidationCode).HasColumnName(nameof(MadfoatcomRequest.ValidationCode));
    b.Property(x => x.JOEBPPSTrx).HasColumnName(nameof(MadfoatcomRequest.JOEBPPSTrx));
    b.Property(x => x.BankTrxId).HasColumnName(nameof(MadfoatcomRequest.BankTrxId));
    b.Property(x => x.BankCode).HasColumnName(nameof(MadfoatcomRequest.BankCode));
    b.Property(x => x.PmtStatus).HasColumnName(nameof(MadfoatcomRequest.PmtStatus));
    b.Property(x => x.PaidAmt).HasColumnName(nameof(MadfoatcomRequest.PaidAmt));
    b.Property(x => x.FeesAmt).HasColumnName(nameof(MadfoatcomRequest.FeesAmt));
    b.Property(x => x.FeesOnBiller).HasColumnName(nameof(MadfoatcomRequest.FeesOnBiller));
    b.Property(x => x.ProcessDate).HasColumnName(nameof(MadfoatcomRequest.ProcessDate));
    b.Property(x => x.StmtDate).HasColumnName(nameof(MadfoatcomRequest.StmtDate));
    b.Property(x => x.AccessChannel).HasColumnName(nameof(MadfoatcomRequest.AccessChannel));
    b.Property(x => x.PaymentMethod).HasColumnName(nameof(MadfoatcomRequest.PaymentMethod));
    b.Property(x => x.PaymentType).HasColumnName(nameof(MadfoatcomRequest.PaymentType));
    b.Property(x => x.Amount).HasColumnName(nameof(MadfoatcomRequest.Amount));
    b.Property(x => x.SetBnkCode).HasColumnName(nameof(MadfoatcomRequest.SetBnkCode));
    b.Property(x => x.AcctNo).HasColumnName(nameof(MadfoatcomRequest.AcctNo));
    b.Property(x => x.Name).HasColumnName(nameof(MadfoatcomRequest.Name));
    b.Property(x => x.Phone).HasColumnName(nameof(MadfoatcomRequest.Phone));
    b.Property(x => x.Address).HasColumnName(nameof(MadfoatcomRequest.Address));
    b.Property(x => x.Email).HasColumnName(nameof(MadfoatcomRequest.Email));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ApiRequestResponseLog>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "ApiRequestResponseLog", "Madfoatcom");
    b.ConfigureByConvention();
    b.Property(x => x.RequestUrl).HasColumnName(nameof(ApiRequestResponseLog.RequestUrl));
    b.Property(x => x.RequestMethod).HasColumnName(nameof(ApiRequestResponseLog.RequestMethod));
    b.Property(x => x.RequestHeaders).HasColumnName(nameof(ApiRequestResponseLog.RequestHeaders));
    b.Property(x => x.RequestBody).HasColumnName(nameof(ApiRequestResponseLog.RequestBody));
    b.Property(x => x.ResponseBody).HasColumnName(nameof(ApiRequestResponseLog.ResponseBody));
    b.Property(x => x.ResponseStatusCode).HasColumnName(nameof(ApiRequestResponseLog.ResponseStatusCode));
    b.Property(x => x.ResponseHeaders).HasColumnName(nameof(ApiRequestResponseLog.ResponseHeaders));
    b.Property(x => x.DurationMs).HasColumnName(nameof(ApiRequestResponseLog.DurationMs));
    b.Property(x => x.CreatedAt).HasColumnName(nameof(ApiRequestResponseLog.CreatedAt));
    b.Property(x => x.CorrelationId).HasColumnName(nameof(ApiRequestResponseLog.CorrelationId));
    b.Property(x => x.IpAddress).HasColumnName(nameof(ApiRequestResponseLog.IpAddress));
    b.Property(x => x.UserId).HasColumnName(nameof(ApiRequestResponseLog.UserId));
    b.Property(x => x.ErrorDetails).HasColumnName(nameof(ApiRequestResponseLog.ErrorDetails));
    b.Property(x => x.IsSuccessful).HasColumnName(nameof(ApiRequestResponseLog.IsSuccessful));
    b.Property(x => x.SourceSystem).HasColumnName(nameof(ApiRequestResponseLog.SourceSystem));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<MadfoatcomResponse>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "MadfoatcomResponse", "Madfoatcom");
    b.ConfigureByConvention();
    b.Property(x => x.BillerCode).HasColumnName(nameof(MadfoatcomResponse.BillerCode));
    b.Property(x => x.BillingNo).HasColumnName(nameof(MadfoatcomResponse.BillingNo));
    b.Property(x => x.BillNo).HasColumnName(nameof(MadfoatcomResponse.BillNo));
    b.Property(x => x.DueAmt).HasColumnName(nameof(MadfoatcomResponse.DueAmt));
    b.Property(x => x.ValidationCode).HasColumnName(nameof(MadfoatcomResponse.ValidationCode));
    b.Property(x => x.ServiceType).HasColumnName(nameof(MadfoatcomResponse.ServiceType));
    b.Property(x => x.PrepaidCat).HasColumnName(nameof(MadfoatcomResponse.PrepaidCat));
    b.Property(x => x.Amount).HasColumnName(nameof(MadfoatcomResponse.Amount));
    b.Property(x => x.SetBnkCode).HasColumnName(nameof(MadfoatcomResponse.SetBnkCode));
    b.Property(x => x.AcctNo).HasColumnName(nameof(MadfoatcomResponse.AcctNo));
    b.Property(x => x.TransferReason).HasColumnName(nameof(MadfoatcomResponse.TransferReason));
    b.Property(x => x.ReceivingCountry).HasColumnName(nameof(MadfoatcomResponse.ReceivingCountry));
    b.Property(x => x.CustName).HasColumnName(nameof(MadfoatcomResponse.CustName));
    b.Property(x => x.Email).HasColumnName(nameof(MadfoatcomResponse.Email));
    b.Property(x => x.Phone).HasColumnName(nameof(MadfoatcomResponse.Phone));
    b.Property(x => x.RecCount).HasColumnName(nameof(MadfoatcomResponse.RecCount));
    b.Property(x => x.BillStatus).HasColumnName(nameof(MadfoatcomResponse.BillStatus));
    b.Property(x => x.DueAmount).HasColumnName(nameof(MadfoatcomResponse.DueAmount));
    b.Property(x => x.IssueDate).HasColumnName(nameof(MadfoatcomResponse.IssueDate));
    b.Property(x => x.OpenDate).HasColumnName(nameof(MadfoatcomResponse.OpenDate));
    b.Property(x => x.DueDate).HasColumnName(nameof(MadfoatcomResponse.DueDate));
    b.Property(x => x.ExpiryDate).HasColumnName(nameof(MadfoatcomResponse.ExpiryDate));
    b.Property(x => x.CloseDate).HasColumnName(nameof(MadfoatcomResponse.CloseDate));
    b.Property(x => x.BillType).HasColumnName(nameof(MadfoatcomResponse.BillType));
    b.Property(x => x.AllowPart).HasColumnName(nameof(MadfoatcomResponse.AllowPart));
    b.Property(x => x.Upper).HasColumnName(nameof(MadfoatcomResponse.Upper));
    b.Property(x => x.Lower).HasColumnName(nameof(MadfoatcomResponse.Lower));
    b.Property(x => x.BillsCount).HasColumnName(nameof(MadfoatcomResponse.BillsCount));
    b.Property(x => x.JOEBPPSTrx).HasColumnName(nameof(MadfoatcomResponse.JOEBPPSTrx));
    b.Property(x => x.ProcessDate).HasColumnName(nameof(MadfoatcomResponse.ProcessDate));
    b.Property(x => x.STMTDate).HasColumnName(nameof(MadfoatcomResponse.STMTDate));
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<OrangeBillPaymentNotificationConfiguration>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "OrangeBillPaymentNotificationConfiguration", "Orange");
    b.ConfigureByConvention();
    b.Property(x => x.ServiceTypeName).HasColumnName(nameof(OrangeBillPaymentNotificationConfiguration.ServiceTypeName)).IsRequired();
    b.Property(x => x.ConfigurationKey).HasColumnName(nameof(OrangeBillPaymentNotificationConfiguration.ConfigurationKey)).IsRequired();
    b.Property(x => x.ConfigurationValue).HasColumnName(nameof(OrangeBillPaymentNotificationConfiguration.ConfigurationValue)).IsRequired();
});

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<OrangeBillPullServiceConfiguration>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "OrangeBillPullServiceConfiguration", "Orange");
    b.ConfigureByConvention();
    b.Property(x => x.ServiceTypeId).HasColumnName(nameof(OrangeBillPullServiceConfiguration.ServiceTypeId));
    b.Property(x => x.IsServiceEnabled).HasColumnName(nameof(OrangeBillPullServiceConfiguration.IsServiceEnabled));
    b.Property(x => x.IsWebServiceEnabled).HasColumnName(nameof(OrangeBillPullServiceConfiguration.IsWebServiceEnabled));
    b.Property(x => x.WebServiceUrl).HasColumnName(nameof(OrangeBillPullServiceConfiguration.WebServiceUrl)).IsRequired();
    b.Property(x => x.StoredProcedureName).HasColumnName(nameof(OrangeBillPullServiceConfiguration.StoredProcedureName));
    b.Property(x => x.BillerCode).HasColumnName(nameof(OrangeBillPullServiceConfiguration.BillerCode));
    b.Property(x => x.ConnectionStringUserId).HasColumnName(nameof(OrangeBillPullServiceConfiguration.ConnectionStringUserId));
    b.Property(x => x.ConnectionStringPassword).HasColumnName(nameof(OrangeBillPullServiceConfiguration.ConnectionStringPassword));
    b.Property(x => x.ConnectionStringDataSource).HasColumnName(nameof(OrangeBillPullServiceConfiguration.ConnectionStringDataSource));
    b.Property(x => x.LogLevel).HasColumnName(nameof(OrangeBillPullServiceConfiguration.LogLevel));
    b.Property(x => x.SeverityId).HasColumnName(nameof(OrangeBillPullServiceConfiguration.SeverityId));
    b.Property(x => x.DailyLimit).HasColumnName(nameof(OrangeBillPullServiceConfiguration.DailyLimit));
    b.Property(x => x.WeeklyLimit).HasColumnName(nameof(OrangeBillPullServiceConfiguration.WeeklyLimit));
    b.Property(x => x.MonthlyLimit).HasColumnName(nameof(OrangeBillPullServiceConfiguration.MonthlyLimit));
    b.Property(x => x.YearlyLimit).HasColumnName(nameof(OrangeBillPullServiceConfiguration.YearlyLimit));
    b.Property(x => x.ErrorMessage).HasColumnName(nameof(OrangeBillPullServiceConfiguration.ErrorMessage));
});

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<PrepaidValidationConfig>(b =>
{
    b.ToTable(ApplicationConsts.DbTablePrefix + "PrepaidValidationConfig", "Orange");
    b.ConfigureByConvention();
    b.Property(x => x.ServiceType).HasColumnName(nameof(PrepaidValidationConfig.ServiceType)).IsRequired();
    b.Property(x => x.ChannelCode).HasColumnName(nameof(PrepaidValidationConfig.ChannelCode));
    b.Property(x => x.BillingName).HasColumnName(nameof(PrepaidValidationConfig.BillingName));
    b.Property(x => x.AliasBillingName).HasColumnName(nameof(PrepaidValidationConfig.AliasBillingName));
    b.Property(x => x.IsTesting).HasColumnName(nameof(PrepaidValidationConfig.IsTesting));
    b.Property(x => x.EndpointUrl).HasColumnName(nameof(PrepaidValidationConfig.EndpointUrl));
});

        }
    }
}