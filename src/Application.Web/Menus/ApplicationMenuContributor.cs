using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Application.Localization;
using Application.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.OpenIddict.Pro.Web.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;

namespace Application.Web.Menus;

public class ApplicationMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ApplicationResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //HostDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.HostDashboard,
                l["Menu:Dashboard"],
                "~/HostDashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(ApplicationPermissions.Dashboard.Host)
        );

        //TenantDashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.TenantDashboard,
                l["Menu:Dashboard"],
                "~/Dashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(ApplicationPermissions.Dashboard.Tenant)
        );

        context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->OpenIddict
        administration.SetSubItemOrder(OpenIddictProMenus.GroupName, 2);

        //Administration->Language Management
        administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

        //Administration->Text Template Management
        administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

        //Administration->Audit Logs
        administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

        #region Lookups Menu

        context.Menu.AddItem(
            new ApplicationMenuItem(ApplicationMenus.Lookups, l["Menu:Lookups"], icon: "fa fa-flag", order: 100)


        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.AccessChannelLookups,
                l["Menu:AccessChannelLookups"],
                url: "/AccessChannelLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.AccessChannelLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.BillingStatusLookups,
                l["Menu:BillingStatusLookups"],
                url: "/BillingStatusLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.BillingStatusLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.BillStatusLookups,
                l["Menu:BillStatusLookups"],
                url: "/BillStatusLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.BillStatusLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.BillTypeLookups,
                l["Menu:BillTypeLookups"],
                url: "/BillTypeLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.BillTypeLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.CharSetLookups,
                l["Menu:CharSetLookups"],
                url: "/CharSetLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.CharSetLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.EmailRecipientSendingStatusLookups,
                l["Menu:EmailRecipientSendingStatusLookups"],
                url: "/EmailRecipientSendingStatusLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.EmailRecipientSendingStatusLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.LanguageIsoNameLookups,
                l["Menu:LanguageIsoNameLookups"],
                url: "/LanguageIsoNameLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.LanguageIsoNameLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.MessageEncodingLookups,
                l["Menu:MessageEncodingLookups"],
                url: "/MessageEncodingLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.MessageEncodingLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.MethodTypeLookups,
                l["Menu:MethodTypeLookups"],
                url: "/MethodTypeLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.MethodTypeLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.OperationTypeLookups,
                l["Menu:OperationTypeLookups"],
                url: "/OperationTypeLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.OperationTypeLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PaymentCurrencyLookups,
                l["Menu:PaymentCurrencyLookups"],
                url: "/PaymentCurrencyLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PaymentCurrencyLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PaymentMethodLookups,
                l["Menu:PaymentMethodLookups"],
                url: "/PaymentMethodLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PaymentMethodLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PaymentSourceLookups,
                l["Menu:PaymentSourceLookups"],
                url: "/PaymentSourceLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PaymentSourceLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PaymentStatusLookups,
                l["Menu:PaymentStatusLookups"],
                url: "/PaymentStatusLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PaymentStatusLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PaymentTypeLookups,
                l["Menu:PaymentTypeLookups"],
                url: "/PaymentTypeLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PaymentTypeLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PrepaidCategoryLookups,
                l["Menu:PrepaidCategoryLookups"],
                url: "/PrepaidCategoryLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PrepaidCategoryLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.ProcessStatusLookups,
                l["Menu:ProcessStatusLookups"],
                url: "/ProcessStatusLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.ProcessStatusLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.ServiceTypeLookups,
                l["Menu:ServiceTypeLookups"],
                url: "/ServiceTypeLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.ServiceTypeLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.SeverityLookups,
                l["Menu:SeverityLookups"],
                url: "/SeverityLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.SeverityLookups.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.ThresholdLookups,
                l["Menu:ThresholdLookups"],
                url: "/ThresholdLookups",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.ThresholdLookups.Default)
        )

         );
        #endregion

        #region Madfoatcom Menu

        context.Menu.AddItem(
            new ApplicationMenuItem(ApplicationMenus.Madfoatcom, l["Menu:Madfoatcom"], icon: "fa fa-flag", order: 100)


        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.ApiRequestResponseLogs,
                l["Menu:ApiRequestResponseLogs"],
                url: "/ApiRequestResponseLogs",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.ApiRequestResponseLogs.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.MadfoatcomRequests,
                l["Menu:MadfoatcomRequests"],
                url: "/MadfoatcomRequests",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.MadfoatcomRequests.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.MadfoatcomResponses,
                l["Menu:MadfoatcomResponses"],
                url: "/MadfoatcomResponses",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.MadfoatcomResponses.Default)
        )

        );


        #endregion

        #region Orange Menu

        context.Menu.AddItem(
            new ApplicationMenuItem(ApplicationMenus.Orange, l["Menu:Orange"], icon: "fa fa-flag", order: 100)


        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.OrangeBillPaymentNotificationConfigurations,
                l["Menu:OrangeBillPaymentNotificationConfigurations"],
                url: "/OrangeBillPaymentNotificationConfigurations",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.OrangeBillPullServiceConfigurations,
                l["Menu:OrangeBillPullServiceConfigurations"],
                url: "/OrangeBillPullServiceConfigurations",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.OrangeBillPullServiceConfigurations.Default)
        )

        .AddItem(
            new ApplicationMenuItem(
                ApplicationMenus.PrepaidValidationConfigs,
                l["Menu:PrepaidValidationConfigs"],
                url: "/PrepaidValidationConfigs",
                icon: "fa fa-file-alt",
                requiredPermissionName: ApplicationPermissions.PrepaidValidationConfigs.Default)
        )
        );

        #endregion

        return Task.CompletedTask;
    }
}