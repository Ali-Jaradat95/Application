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
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;

namespace Application.EntityFrameworkCore;

[DependsOn(
    typeof(ApplicationDomainModule),
    typeof(AbpIdentityProEntityFrameworkCoreModule),
    typeof(AbpOpenIddictProEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(LanguageManagementEntityFrameworkCoreModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(TextTemplateManagementEntityFrameworkCoreModule),
    typeof(AbpGdprEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
)]
[DependsOn(typeof(ChatEntityFrameworkCoreModule))]
[DependsOn(typeof(FileManagementEntityFrameworkCoreModule))]
public class ApplicationEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ApplicationEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ApplicationDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<AccessChannelLookup, AccessChannelLookups.EfCoreAccessChannelLookupRepository>();

            options.AddRepository<BillingStatusLookup, BillingStatusLookups.EfCoreBillingStatusLookupRepository>();

            options.AddRepository<BillStatusLookup, BillStatusLookups.EfCoreBillStatusLookupRepository>();

            options.AddRepository<BillTypeLookup, BillTypeLookups.EfCoreBillTypeLookupRepository>();

            options.AddRepository<CharSetLookup, CharSetLookups.EfCoreCharSetLookupRepository>();

            options.AddRepository<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookups.EfCoreEmailRecipientSendingStatusLookupRepository>();

            options.AddRepository<LanguageIsoNameLookup, LanguageIsoNameLookups.EfCoreLanguageIsoNameLookupRepository>();

            options.AddRepository<MessageEncodingLookup, MessageEncodingLookups.EfCoreMessageEncodingLookupRepository>();

            options.AddRepository<MethodTypeLookup, MethodTypeLookups.EfCoreMethodTypeLookupRepository>();

            options.AddRepository<OperationTypeLookup, OperationTypeLookups.EfCoreOperationTypeLookupRepository>();

            options.AddRepository<PaymentCurrencyLookup, PaymentCurrencyLookups.EfCorePaymentCurrencyLookupRepository>();

            options.AddRepository<PaymentMethodLookup, PaymentMethodLookups.EfCorePaymentMethodLookupRepository>();

            options.AddRepository<PaymentSourceLookup, PaymentSourceLookups.EfCorePaymentSourceLookupRepository>();

            options.AddRepository<PaymentStatusLookup, PaymentStatusLookups.EfCorePaymentStatusLookupRepository>();

            options.AddRepository<PaymentTypeLookup, PaymentTypeLookups.EfCorePaymentTypeLookupRepository>();

            options.AddRepository<PrepaidCategoryLookup, PrepaidCategoryLookups.EfCorePrepaidCategoryLookupRepository>();

            options.AddRepository<ProcessStatusLookup, ProcessStatusLookups.EfCoreProcessStatusLookupRepository>();

            options.AddRepository<ServiceTypeLookup, ServiceTypeLookups.EfCoreServiceTypeLookupRepository>();

            options.AddRepository<SeverityLookup, SeverityLookups.EfCoreSeverityLookupRepository>();

            options.AddRepository<ThresholdLookup, ThresholdLookups.EfCoreThresholdLookupRepository>();

            options.AddRepository<ApiRequestResponseLog, ApiRequestResponseLogs.EfCoreApiRequestResponseLogRepository>();

            options.AddRepository<MadfoatcomRequest, MadfoatcomRequests.EfCoreMadfoatcomRequestRepository>();

            options.AddRepository<MadfoatcomResponse, MadfoatcomResponses.EfCoreMadfoatcomResponseRepository>();

            options.AddRepository<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurations.EfCoreOrangeBillPaymentNotificationConfigurationRepository>();

            options.AddRepository<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurations.EfCoreOrangeBillPullServiceConfigurationRepository>();

            options.AddRepository<PrepaidValidationConfig, PrepaidValidationConfigs.EfCorePrepaidValidationConfigRepository>();

        });

        context.Services.AddAbpDbContext<ApplicationTenantDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also ApplicationDbContextFactoryBase for EF Core tooling. */
            options.UseSqlServer();
        });

    }
}