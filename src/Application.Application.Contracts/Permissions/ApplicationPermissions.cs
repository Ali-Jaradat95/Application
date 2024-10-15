namespace Application.Permissions;

public static class ApplicationPermissions
{
    public const string GroupName = "Application";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class AccessChannelLookups
    {
        public const string Default = GroupName + ".AccessChannelLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class BillingStatusLookups
    {
        public const string Default = GroupName + ".BillingStatusLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class BillStatusLookups
    {
        public const string Default = GroupName + ".BillStatusLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class BillTypeLookups
    {
        public const string Default = GroupName + ".BillTypeLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class CharSetLookups
    {
        public const string Default = GroupName + ".CharSetLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class EmailRecipientSendingStatusLookups
    {
        public const string Default = GroupName + ".EmailRecipientSendingStatusLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class LanguageIsoNameLookups
    {
        public const string Default = GroupName + ".LanguageIsoNameLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class MessageEncodingLookups
    {
        public const string Default = GroupName + ".MessageEncodingLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class MethodTypeLookups
    {
        public const string Default = GroupName + ".MethodTypeLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class OperationTypeLookups
    {
        public const string Default = GroupName + ".OperationTypeLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PaymentCurrencyLookups
    {
        public const string Default = GroupName + ".PaymentCurrencyLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PaymentMethodLookups
    {
        public const string Default = GroupName + ".PaymentMethodLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PaymentSourceLookups
    {
        public const string Default = GroupName + ".PaymentSourceLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PaymentStatusLookups
    {
        public const string Default = GroupName + ".PaymentStatusLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PaymentTypeLookups
    {
        public const string Default = GroupName + ".PaymentTypeLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PrepaidCategoryLookups
    {
        public const string Default = GroupName + ".PrepaidCategoryLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ProcessStatusLookups
    {
        public const string Default = GroupName + ".ProcessStatusLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ServiceTypeLookups
    {
        public const string Default = GroupName + ".ServiceTypeLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class SeverityLookups
    {
        public const string Default = GroupName + ".SeverityLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ThresholdLookups
    {
        public const string Default = GroupName + ".ThresholdLookups";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class ApiRequestResponseLogs
    {
        public const string Default = GroupName + ".ApiRequestResponseLogs";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class MadfoatcomRequests
    {
        public const string Default = GroupName + ".MadfoatcomRequests";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class MadfoatcomResponses
    {
        public const string Default = GroupName + ".MadfoatcomResponses";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class OrangeBillPaymentNotificationConfigurations
    {
        public const string Default = GroupName + ".OrangeBillPaymentNotificationConfigurations";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class OrangeBillPullServiceConfigurations
    {
        public const string Default = GroupName + ".OrangeBillPullServiceConfigurations";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PrepaidValidationConfigs
    {
        public const string Default = GroupName + ".PrepaidValidationConfigs";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}