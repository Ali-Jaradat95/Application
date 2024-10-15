using System.IO;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.EntityFrameworkCore;
using Application.Localization;
using Application.MultiTenancy;
using Application.Permissions;
using Application.Web.Menus;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Admin.Web;
using Volo.Abp.Account.Public.Web;
using Volo.Abp.Account.Public.Web.ExternalProviders;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Commercial;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AuditLogging.Web;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.TextTemplateManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Saas.Host;
using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Application.Web.HealthChecks;
using OpenIddict.Server.AspNetCore;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp.Account.Pro.Public.Web.Shared;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonX;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonX.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Identity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.Gdpr.Web;
using Volo.Abp.Gdpr.Web.Extensions;
using Volo.Abp.LeptonX.Shared;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Pro.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Chat;
using Volo.Chat.Web;
using Volo.FileManagement.Web;

namespace Application.Web;

[DependsOn(
    typeof(ApplicationHttpApiModule),
    typeof(ApplicationApplicationModule),
    typeof(ApplicationEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpIdentityWebModule),
    typeof(AbpAccountPublicWebOpenIddictModule),
    typeof(AbpAuditLoggingWebModule),
    typeof(SaasHostWebModule),
    typeof(AbpAccountAdminWebModule),
    typeof(AbpOpenIddictProWebModule),
    typeof(LanguageManagementWebModule),
    typeof(AbpAspNetCoreMvcUiLeptonXThemeModule),
    typeof(TextTemplateManagementWebModule),
    typeof(AbpGdprWebModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
[DependsOn(typeof(ChatSignalRModule))]
[DependsOn(typeof(ChatWebModule))]
[DependsOn(typeof(FileManagementWebModule))]
public class ApplicationWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(ApplicationResource),
                typeof(ApplicationDomainModule).Assembly,
                typeof(ApplicationDomainSharedModule).Assembly,
                typeof(ApplicationApplicationModule).Assembly,
                typeof(ApplicationApplicationContractsModule).Assembly,
                typeof(ApplicationWebModule).Assembly
            );
        });

        PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences("Application");
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        });

        if (!hostingEnvironment.IsDevelopment())
        {
            PreConfigure<AbpOpenIddictAspNetCoreOptions>(options =>
            {
                options.AddDevelopmentEncryptionAndSigningCertificate = false;
            });

            PreConfigure<OpenIddictServerBuilder>(builder =>
            {
                builder.AddSigningCertificate(GetSigningCertificate(hostingEnvironment, configuration));
                builder.AddEncryptionCertificate(GetSigningCertificate(hostingEnvironment, configuration));
                builder.SetIssuer(new Uri(configuration["AuthServer:Authority"]!));
            });
        }
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        if (!Convert.ToBoolean(configuration["App:DisablePII"]))
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
        }

        if (!Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]))
        {
            Configure<OpenIddictServerAspNetCoreOptions>(options =>
            {
                options.DisableTransportSecurityRequirement = true;
            });
        }

        ConfigureBundles();
        ConfigureUrls(configuration);
        ConfigurePages(configuration);
        ConfigureAuthentication(context);
        ConfigureImpersonation(context, configuration);
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureNavigationServices();
        ConfigureAutoApiControllers();
        ConfigureSwaggerServices(context.Services);
        ConfigureExternalProviders(context);
        ConfigureHealthChecks(context);
        ConfigureCookieConsent(context);
        ConfigureTheme();

        Configure<PermissionManagementOptions>(options =>
        {
            options.IsDynamicPermissionStoreEnabled = true;
        });
    }

    private void ConfigureCookieConsent(ServiceConfigurationContext context)
    {
        context.Services.AddAbpCookieConsent(options =>
        {
            options.IsEnabled = true;
            options.CookiePolicyUrl = "/CookiePolicy";
            options.PrivacyPolicyUrl = "/PrivacyPolicy";
        });
    }

    private void ConfigureTheme()
    {
        Configure<LeptonXThemeOptions>(options =>
        {
            options.DefaultStyle = LeptonXStyleNames.System;
        });
    }

    private void ConfigureHealthChecks(ServiceConfigurationContext context)
    {
        context.Services.AddApplicationHealthChecks();
    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                LeptonXThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                }
            );
        });
    }

    private void ConfigurePages(IConfiguration configuration)
    {
        Configure<RazorPagesOptions>(options =>
        {
            options.Conventions.AuthorizePage("/HostDashboard", ApplicationPermissions.Dashboard.Host);
            options.Conventions.AuthorizePage("/TenantDashboard", ApplicationPermissions.Dashboard.Tenant);
            options.Conventions.AuthorizePage("/AccessChannelLookups/Index", ApplicationPermissions.AccessChannelLookups.Default);
            options.Conventions.AuthorizePage("/BillingStatusLookups/Index", ApplicationPermissions.BillingStatusLookups.Default);
            options.Conventions.AuthorizePage("/BillStatusLookups/Index", ApplicationPermissions.BillStatusLookups.Default);
            options.Conventions.AuthorizePage("/BillTypeLookups/Index", ApplicationPermissions.BillTypeLookups.Default);
            options.Conventions.AuthorizePage("/CharSetLookups/Index", ApplicationPermissions.CharSetLookups.Default);
            options.Conventions.AuthorizePage("/EmailRecipientSendingStatusLookups/Index", ApplicationPermissions.EmailRecipientSendingStatusLookups.Default);
            options.Conventions.AuthorizePage("/LanguageIsoNameLookups/Index", ApplicationPermissions.LanguageIsoNameLookups.Default);
            options.Conventions.AuthorizePage("/MessageEncodingLookups/Index", ApplicationPermissions.MessageEncodingLookups.Default);
            options.Conventions.AuthorizePage("/MethodTypeLookups/Index", ApplicationPermissions.MethodTypeLookups.Default);
            options.Conventions.AuthorizePage("/OperationTypeLookups/Index", ApplicationPermissions.OperationTypeLookups.Default);
            options.Conventions.AuthorizePage("/PaymentCurrencyLookups/Index", ApplicationPermissions.PaymentCurrencyLookups.Default);
            options.Conventions.AuthorizePage("/PaymentMethodLookups/Index", ApplicationPermissions.PaymentMethodLookups.Default);
            options.Conventions.AuthorizePage("/PaymentSourceLookups/Index", ApplicationPermissions.PaymentSourceLookups.Default);
            options.Conventions.AuthorizePage("/PaymentStatusLookups/Index", ApplicationPermissions.PaymentStatusLookups.Default);
            options.Conventions.AuthorizePage("/PaymentTypeLookups/Index", ApplicationPermissions.PaymentTypeLookups.Default);
            options.Conventions.AuthorizePage("/PrepaidCategoryLookups/Index", ApplicationPermissions.PrepaidCategoryLookups.Default);
            options.Conventions.AuthorizePage("/ProcessStatusLookups/Index", ApplicationPermissions.ProcessStatusLookups.Default);
            options.Conventions.AuthorizePage("/ServiceTypeLookups/Index", ApplicationPermissions.ServiceTypeLookups.Default);
            options.Conventions.AuthorizePage("/SeverityLookups/Index", ApplicationPermissions.SeverityLookups.Default);
            options.Conventions.AuthorizePage("/ThresholdLookups/Index", ApplicationPermissions.ThresholdLookups.Default);
            options.Conventions.AuthorizePage("/ApiRequestResponseLogs/Index", ApplicationPermissions.ApiRequestResponseLogs.Default);
            options.Conventions.AuthorizePage("/MadfoatcomRequests/Index", ApplicationPermissions.MadfoatcomRequests.Default);
            options.Conventions.AuthorizePage("/MadfoatcomResponses/Index", ApplicationPermissions.MadfoatcomResponses.Default);
            options.Conventions.AuthorizePage("/OrangeBillPaymentNotificationConfigurations/Index", ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Default);
            options.Conventions.AuthorizePage("/OrangeBillPullServiceConfigurations/Index", ApplicationPermissions.OrangeBillPullServiceConfigurations.Default);
            options.Conventions.AuthorizePage("/PrepaidValidationConfigs/Index", ApplicationPermissions.PrepaidValidationConfigs.Default);
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
    }

    private void ConfigureImpersonation(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.Configure<AbpSaasHostWebOptions>(options =>
        {
            options.EnableTenantImpersonation = true;
        });
        context.Services.Configure<AbpIdentityWebOptions>(options =>
        {
            options.EnableUserImpersonation = true;
        });
        context.Services.Configure<AbpAccountOptions>(options =>
        {
            options.TenantAdminUserName = "admin";
            options.ImpersonationTenantPermission = SaasHostPermissions.Tenants.Impersonation;
            options.ImpersonationUserPermission = IdentityPermissions.Users.Impersonation;
        });
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApplicationWebModule>();
        });
    }

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ApplicationWebModule>();

            if (hostingEnvironment.IsDevelopment())
            {
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Application.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Application.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Application.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Application.Application", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationHttpApiModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Application.HttpApi", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<ApplicationWebModule>(hostingEnvironment.ContentRootPath);
            }
        });
    }

    private void ConfigureNavigationServices()
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ApplicationMenuContributor());
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new ApplicationToolbarContributor());
        });
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(ApplicationApplicationModule).Assembly);
        });
    }

    private void ConfigureSwaggerServices(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Application API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    private void ConfigureExternalProviders(ServiceConfigurationContext context)
    {
        context.Services.AddAuthentication()
            .AddGoogle(GoogleDefaults.AuthenticationScheme, _ => { })
            .WithDynamicOptions<GoogleOptions, GoogleHandler>(
                GoogleDefaults.AuthenticationScheme,
                options =>
                {
                    options.WithProperty(x => x.ClientId);
                    options.WithProperty(x => x.ClientSecret, isSecret: true);
                }
            )
            .AddMicrosoftAccount(MicrosoftAccountDefaults.AuthenticationScheme, options =>
            {
                //Personal Microsoft accounts as an example.
                options.AuthorizationEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/authorize";
                options.TokenEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/token";
            })
            .WithDynamicOptions<MicrosoftAccountOptions, MicrosoftAccountHandler>(
                MicrosoftAccountDefaults.AuthenticationScheme,
                options =>
                {
                    options.WithProperty(x => x.ClientId);
                    options.WithProperty(x => x.ClientSecret, isSecret: true);
                }
            )
            .AddTwitter(TwitterDefaults.AuthenticationScheme, options => options.RetrieveUserDetails = true)
            .WithDynamicOptions<TwitterOptions, TwitterHandler>(
                TwitterDefaults.AuthenticationScheme,
                options =>
                {
                    options.WithProperty(x => x.ConsumerKey);
                    options.WithProperty(x => x.ConsumerSecret, isSecret: true);
                }
            );
    }

    private X509Certificate2 GetSigningCertificate(IWebHostEnvironment hostingEnv, IConfiguration configuration)
    {
        var fileName = "authserver.pfx";
        var passPhrase = "44f45d9f-0a3a-4dcf-b016-abfc70d01cfe";
        var file = Path.Combine(hostingEnv.ContentRootPath, fileName);

        if (!File.Exists(file))
        {
            throw new FileNotFoundException($"Signing Certificate couldn't found: {file}");
        }

        return new X509Certificate2(file, passPhrase);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
            app.UseHsts();
        }

        app.UseAbpCookieConsent();
        app.UseCorrelationId();
        app.UseAbpSecurityHeaders();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Application API");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}