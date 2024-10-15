using Application.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Application.Permissions;

public class ApplicationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ApplicationPermissions.GroupName);

        myGroup.AddPermission(ApplicationPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(ApplicationPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ApplicationPermissions.MyPermission1, L("Permission:MyPermission1"));

        var accessChannelLookupPermission = myGroup.AddPermission(ApplicationPermissions.AccessChannelLookups.Default, L("Permission:AccessChannelLookups"));
        accessChannelLookupPermission.AddChild(ApplicationPermissions.AccessChannelLookups.Create, L("Permission:Create"));
        accessChannelLookupPermission.AddChild(ApplicationPermissions.AccessChannelLookups.Edit, L("Permission:Edit"));
        accessChannelLookupPermission.AddChild(ApplicationPermissions.AccessChannelLookups.Delete, L("Permission:Delete"));

        var billingStatusLookupPermission = myGroup.AddPermission(ApplicationPermissions.BillingStatusLookups.Default, L("Permission:BillingStatusLookups"));
        billingStatusLookupPermission.AddChild(ApplicationPermissions.BillingStatusLookups.Create, L("Permission:Create"));
        billingStatusLookupPermission.AddChild(ApplicationPermissions.BillingStatusLookups.Edit, L("Permission:Edit"));
        billingStatusLookupPermission.AddChild(ApplicationPermissions.BillingStatusLookups.Delete, L("Permission:Delete"));

        var billStatusLookupPermission = myGroup.AddPermission(ApplicationPermissions.BillStatusLookups.Default, L("Permission:BillStatusLookups"));
        billStatusLookupPermission.AddChild(ApplicationPermissions.BillStatusLookups.Create, L("Permission:Create"));
        billStatusLookupPermission.AddChild(ApplicationPermissions.BillStatusLookups.Edit, L("Permission:Edit"));
        billStatusLookupPermission.AddChild(ApplicationPermissions.BillStatusLookups.Delete, L("Permission:Delete"));

        var billTypeLookupPermission = myGroup.AddPermission(ApplicationPermissions.BillTypeLookups.Default, L("Permission:BillTypeLookups"));
        billTypeLookupPermission.AddChild(ApplicationPermissions.BillTypeLookups.Create, L("Permission:Create"));
        billTypeLookupPermission.AddChild(ApplicationPermissions.BillTypeLookups.Edit, L("Permission:Edit"));
        billTypeLookupPermission.AddChild(ApplicationPermissions.BillTypeLookups.Delete, L("Permission:Delete"));

        var charSetLookupPermission = myGroup.AddPermission(ApplicationPermissions.CharSetLookups.Default, L("Permission:CharSetLookups"));
        charSetLookupPermission.AddChild(ApplicationPermissions.CharSetLookups.Create, L("Permission:Create"));
        charSetLookupPermission.AddChild(ApplicationPermissions.CharSetLookups.Edit, L("Permission:Edit"));
        charSetLookupPermission.AddChild(ApplicationPermissions.CharSetLookups.Delete, L("Permission:Delete"));

        var emailRecipientSendingStatusLookupPermission = myGroup.AddPermission(ApplicationPermissions.EmailRecipientSendingStatusLookups.Default, L("Permission:EmailRecipientSendingStatusLookups"));
        emailRecipientSendingStatusLookupPermission.AddChild(ApplicationPermissions.EmailRecipientSendingStatusLookups.Create, L("Permission:Create"));
        emailRecipientSendingStatusLookupPermission.AddChild(ApplicationPermissions.EmailRecipientSendingStatusLookups.Edit, L("Permission:Edit"));
        emailRecipientSendingStatusLookupPermission.AddChild(ApplicationPermissions.EmailRecipientSendingStatusLookups.Delete, L("Permission:Delete"));

        var languageIsoNameLookupPermission = myGroup.AddPermission(ApplicationPermissions.LanguageIsoNameLookups.Default, L("Permission:LanguageIsoNameLookups"));
        languageIsoNameLookupPermission.AddChild(ApplicationPermissions.LanguageIsoNameLookups.Create, L("Permission:Create"));
        languageIsoNameLookupPermission.AddChild(ApplicationPermissions.LanguageIsoNameLookups.Edit, L("Permission:Edit"));
        languageIsoNameLookupPermission.AddChild(ApplicationPermissions.LanguageIsoNameLookups.Delete, L("Permission:Delete"));

        var messageEncodingLookupPermission = myGroup.AddPermission(ApplicationPermissions.MessageEncodingLookups.Default, L("Permission:MessageEncodingLookups"));
        messageEncodingLookupPermission.AddChild(ApplicationPermissions.MessageEncodingLookups.Create, L("Permission:Create"));
        messageEncodingLookupPermission.AddChild(ApplicationPermissions.MessageEncodingLookups.Edit, L("Permission:Edit"));
        messageEncodingLookupPermission.AddChild(ApplicationPermissions.MessageEncodingLookups.Delete, L("Permission:Delete"));

        var methodTypeLookupPermission = myGroup.AddPermission(ApplicationPermissions.MethodTypeLookups.Default, L("Permission:MethodTypeLookups"));
        methodTypeLookupPermission.AddChild(ApplicationPermissions.MethodTypeLookups.Create, L("Permission:Create"));
        methodTypeLookupPermission.AddChild(ApplicationPermissions.MethodTypeLookups.Edit, L("Permission:Edit"));
        methodTypeLookupPermission.AddChild(ApplicationPermissions.MethodTypeLookups.Delete, L("Permission:Delete"));

        var operationTypeLookupPermission = myGroup.AddPermission(ApplicationPermissions.OperationTypeLookups.Default, L("Permission:OperationTypeLookups"));
        operationTypeLookupPermission.AddChild(ApplicationPermissions.OperationTypeLookups.Create, L("Permission:Create"));
        operationTypeLookupPermission.AddChild(ApplicationPermissions.OperationTypeLookups.Edit, L("Permission:Edit"));
        operationTypeLookupPermission.AddChild(ApplicationPermissions.OperationTypeLookups.Delete, L("Permission:Delete"));

        var paymentCurrencyLookupPermission = myGroup.AddPermission(ApplicationPermissions.PaymentCurrencyLookups.Default, L("Permission:PaymentCurrencyLookups"));
        paymentCurrencyLookupPermission.AddChild(ApplicationPermissions.PaymentCurrencyLookups.Create, L("Permission:Create"));
        paymentCurrencyLookupPermission.AddChild(ApplicationPermissions.PaymentCurrencyLookups.Edit, L("Permission:Edit"));
        paymentCurrencyLookupPermission.AddChild(ApplicationPermissions.PaymentCurrencyLookups.Delete, L("Permission:Delete"));

        var paymentMethodLookupPermission = myGroup.AddPermission(ApplicationPermissions.PaymentMethodLookups.Default, L("Permission:PaymentMethodLookups"));
        paymentMethodLookupPermission.AddChild(ApplicationPermissions.PaymentMethodLookups.Create, L("Permission:Create"));
        paymentMethodLookupPermission.AddChild(ApplicationPermissions.PaymentMethodLookups.Edit, L("Permission:Edit"));
        paymentMethodLookupPermission.AddChild(ApplicationPermissions.PaymentMethodLookups.Delete, L("Permission:Delete"));

        var paymentSourceLookupPermission = myGroup.AddPermission(ApplicationPermissions.PaymentSourceLookups.Default, L("Permission:PaymentSourceLookups"));
        paymentSourceLookupPermission.AddChild(ApplicationPermissions.PaymentSourceLookups.Create, L("Permission:Create"));
        paymentSourceLookupPermission.AddChild(ApplicationPermissions.PaymentSourceLookups.Edit, L("Permission:Edit"));
        paymentSourceLookupPermission.AddChild(ApplicationPermissions.PaymentSourceLookups.Delete, L("Permission:Delete"));

        var paymentStatusLookupPermission = myGroup.AddPermission(ApplicationPermissions.PaymentStatusLookups.Default, L("Permission:PaymentStatusLookups"));
        paymentStatusLookupPermission.AddChild(ApplicationPermissions.PaymentStatusLookups.Create, L("Permission:Create"));
        paymentStatusLookupPermission.AddChild(ApplicationPermissions.PaymentStatusLookups.Edit, L("Permission:Edit"));
        paymentStatusLookupPermission.AddChild(ApplicationPermissions.PaymentStatusLookups.Delete, L("Permission:Delete"));

        var paymentTypeLookupPermission = myGroup.AddPermission(ApplicationPermissions.PaymentTypeLookups.Default, L("Permission:PaymentTypeLookups"));
        paymentTypeLookupPermission.AddChild(ApplicationPermissions.PaymentTypeLookups.Create, L("Permission:Create"));
        paymentTypeLookupPermission.AddChild(ApplicationPermissions.PaymentTypeLookups.Edit, L("Permission:Edit"));
        paymentTypeLookupPermission.AddChild(ApplicationPermissions.PaymentTypeLookups.Delete, L("Permission:Delete"));

        var prepaidCategoryLookupPermission = myGroup.AddPermission(ApplicationPermissions.PrepaidCategoryLookups.Default, L("Permission:PrepaidCategoryLookups"));
        prepaidCategoryLookupPermission.AddChild(ApplicationPermissions.PrepaidCategoryLookups.Create, L("Permission:Create"));
        prepaidCategoryLookupPermission.AddChild(ApplicationPermissions.PrepaidCategoryLookups.Edit, L("Permission:Edit"));
        prepaidCategoryLookupPermission.AddChild(ApplicationPermissions.PrepaidCategoryLookups.Delete, L("Permission:Delete"));

        var processStatusLookupPermission = myGroup.AddPermission(ApplicationPermissions.ProcessStatusLookups.Default, L("Permission:ProcessStatusLookups"));
        processStatusLookupPermission.AddChild(ApplicationPermissions.ProcessStatusLookups.Create, L("Permission:Create"));
        processStatusLookupPermission.AddChild(ApplicationPermissions.ProcessStatusLookups.Edit, L("Permission:Edit"));
        processStatusLookupPermission.AddChild(ApplicationPermissions.ProcessStatusLookups.Delete, L("Permission:Delete"));

        var serviceTypeLookupPermission = myGroup.AddPermission(ApplicationPermissions.ServiceTypeLookups.Default, L("Permission:ServiceTypeLookups"));
        serviceTypeLookupPermission.AddChild(ApplicationPermissions.ServiceTypeLookups.Create, L("Permission:Create"));
        serviceTypeLookupPermission.AddChild(ApplicationPermissions.ServiceTypeLookups.Edit, L("Permission:Edit"));
        serviceTypeLookupPermission.AddChild(ApplicationPermissions.ServiceTypeLookups.Delete, L("Permission:Delete"));

        var severityLookupPermission = myGroup.AddPermission(ApplicationPermissions.SeverityLookups.Default, L("Permission:SeverityLookups"));
        severityLookupPermission.AddChild(ApplicationPermissions.SeverityLookups.Create, L("Permission:Create"));
        severityLookupPermission.AddChild(ApplicationPermissions.SeverityLookups.Edit, L("Permission:Edit"));
        severityLookupPermission.AddChild(ApplicationPermissions.SeverityLookups.Delete, L("Permission:Delete"));

        var thresholdLookupPermission = myGroup.AddPermission(ApplicationPermissions.ThresholdLookups.Default, L("Permission:ThresholdLookups"));
        thresholdLookupPermission.AddChild(ApplicationPermissions.ThresholdLookups.Create, L("Permission:Create"));
        thresholdLookupPermission.AddChild(ApplicationPermissions.ThresholdLookups.Edit, L("Permission:Edit"));
        thresholdLookupPermission.AddChild(ApplicationPermissions.ThresholdLookups.Delete, L("Permission:Delete"));

        var apiRequestResponseLogPermission = myGroup.AddPermission(ApplicationPermissions.ApiRequestResponseLogs.Default, L("Permission:ApiRequestResponseLogs"));
        apiRequestResponseLogPermission.AddChild(ApplicationPermissions.ApiRequestResponseLogs.Create, L("Permission:Create"));
        apiRequestResponseLogPermission.AddChild(ApplicationPermissions.ApiRequestResponseLogs.Edit, L("Permission:Edit"));
        apiRequestResponseLogPermission.AddChild(ApplicationPermissions.ApiRequestResponseLogs.Delete, L("Permission:Delete"));

        var madfoatcomRequestPermission = myGroup.AddPermission(ApplicationPermissions.MadfoatcomRequests.Default, L("Permission:MadfoatcomRequests"));
        madfoatcomRequestPermission.AddChild(ApplicationPermissions.MadfoatcomRequests.Create, L("Permission:Create"));
        madfoatcomRequestPermission.AddChild(ApplicationPermissions.MadfoatcomRequests.Edit, L("Permission:Edit"));
        madfoatcomRequestPermission.AddChild(ApplicationPermissions.MadfoatcomRequests.Delete, L("Permission:Delete"));

        var madfoatcomResponsePermission = myGroup.AddPermission(ApplicationPermissions.MadfoatcomResponses.Default, L("Permission:MadfoatcomResponses"));
        madfoatcomResponsePermission.AddChild(ApplicationPermissions.MadfoatcomResponses.Create, L("Permission:Create"));
        madfoatcomResponsePermission.AddChild(ApplicationPermissions.MadfoatcomResponses.Edit, L("Permission:Edit"));
        madfoatcomResponsePermission.AddChild(ApplicationPermissions.MadfoatcomResponses.Delete, L("Permission:Delete"));

        var orangeBillPaymentNotificationConfigurationPermission = myGroup.AddPermission(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Default, L("Permission:OrangeBillPaymentNotificationConfigurations"));
        orangeBillPaymentNotificationConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Create, L("Permission:Create"));
        orangeBillPaymentNotificationConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Edit, L("Permission:Edit"));
        orangeBillPaymentNotificationConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPaymentNotificationConfigurations.Delete, L("Permission:Delete"));

        var orangeBillPullServiceConfigurationPermission = myGroup.AddPermission(ApplicationPermissions.OrangeBillPullServiceConfigurations.Default, L("Permission:OrangeBillPullServiceConfigurations"));
        orangeBillPullServiceConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPullServiceConfigurations.Create, L("Permission:Create"));
        orangeBillPullServiceConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPullServiceConfigurations.Edit, L("Permission:Edit"));
        orangeBillPullServiceConfigurationPermission.AddChild(ApplicationPermissions.OrangeBillPullServiceConfigurations.Delete, L("Permission:Delete"));

        var prepaidValidationConfigPermission = myGroup.AddPermission(ApplicationPermissions.PrepaidValidationConfigs.Default, L("Permission:PrepaidValidationConfigs"));
        prepaidValidationConfigPermission.AddChild(ApplicationPermissions.PrepaidValidationConfigs.Create, L("Permission:Create"));
        prepaidValidationConfigPermission.AddChild(ApplicationPermissions.PrepaidValidationConfigs.Edit, L("Permission:Edit"));
        prepaidValidationConfigPermission.AddChild(ApplicationPermissions.PrepaidValidationConfigs.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApplicationResource>(name);
    }
}