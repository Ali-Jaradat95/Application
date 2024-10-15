using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppThresholdLookup",
                table: "AppThresholdLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSeverityLookup",
                table: "AppSeverityLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppServiceTypeLookup",
                table: "AppServiceTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProcessStatusLookup",
                table: "AppProcessStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPrepaidValidationConfig",
                table: "AppPrepaidValidationConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPrepaidCategoryLookup",
                table: "AppPrepaidCategoryLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPaymentTypeLookup",
                table: "AppPaymentTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPaymentStatusLookup",
                table: "AppPaymentStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPaymentSourceLookup",
                table: "AppPaymentSourceLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPaymentMethodLookup",
                table: "AppPaymentMethodLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPaymentCurrencyLookup",
                table: "AppPaymentCurrencyLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrangeBillPullServiceConfiguration",
                table: "AppOrangeBillPullServiceConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrangeBillPaymentNotificationConfiguration",
                table: "AppOrangeBillPaymentNotificationConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOperationTypeLookup",
                table: "AppOperationTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMethodTypeLookup",
                table: "AppMethodTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMessageEncodingLookup",
                table: "AppMessageEncodingLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMadfoatcomResponse",
                table: "AppMadfoatcomResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMadfoatcomRequest",
                table: "AppMadfoatcomRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLanguageIsoNameLookup",
                table: "AppLanguageIsoNameLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEmailRecipientSendingStatusLookup",
                table: "AppEmailRecipientSendingStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCharSetLookup",
                table: "AppCharSetLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBillTypeLookup",
                table: "AppBillTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBillStatusLookup",
                table: "AppBillStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBillingStatusLookup",
                table: "AppBillingStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppApiRequestResponseLog",
                table: "AppApiRequestResponseLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppAccessChannelLookup",
                table: "AppAccessChannelLookup");

            migrationBuilder.EnsureSchema(
                name: "Lookups");

            migrationBuilder.EnsureSchema(
                name: "Madfoatcom");

            migrationBuilder.EnsureSchema(
                name: "Orange");

            migrationBuilder.RenameTable(
                name: "AppThresholdLookup",
                newName: "ThresholdLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppSeverityLookup",
                newName: "SeverityLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppServiceTypeLookup",
                newName: "ServiceTypeLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppProcessStatusLookup",
                newName: "ProcessStatusLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPrepaidValidationConfig",
                newName: "PrepaidValidationConfig",
                newSchema: "Orange");

            migrationBuilder.RenameTable(
                name: "AppPrepaidCategoryLookup",
                newName: "PrepaidCategoryLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPaymentTypeLookup",
                newName: "PaymentTypeLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPaymentStatusLookup",
                newName: "PaymentStatusLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPaymentSourceLookup",
                newName: "PaymentSourceLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPaymentMethodLookup",
                newName: "PaymentMethodLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppPaymentCurrencyLookup",
                newName: "PaymentCurrencyLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppOrangeBillPullServiceConfiguration",
                newName: "OrangeBillPullServiceConfiguration",
                newSchema: "Orange");

            migrationBuilder.RenameTable(
                name: "AppOrangeBillPaymentNotificationConfiguration",
                newName: "OrangeBillPaymentNotificationConfiguration",
                newSchema: "Orange");

            migrationBuilder.RenameTable(
                name: "AppOperationTypeLookup",
                newName: "OperationTypeLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppMethodTypeLookup",
                newName: "MethodTypeLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppMessageEncodingLookup",
                newName: "MessageEncodingLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppMadfoatcomResponse",
                newName: "MadfoatcomResponse",
                newSchema: "Madfoatcom");

            migrationBuilder.RenameTable(
                name: "AppMadfoatcomRequest",
                newName: "MadfoatcomRequest",
                newSchema: "Madfoatcom");

            migrationBuilder.RenameTable(
                name: "AppLanguageIsoNameLookup",
                newName: "LanguageIsoNameLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppEmailRecipientSendingStatusLookup",
                newName: "EmailRecipientSendingStatusLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppCharSetLookup",
                newName: "CharSetLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppBillTypeLookup",
                newName: "BillTypeLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppBillStatusLookup",
                newName: "BillStatusLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppBillingStatusLookup",
                newName: "BillingStatusLookup",
                newSchema: "Lookups");

            migrationBuilder.RenameTable(
                name: "AppApiRequestResponseLog",
                newName: "ApiRequestResponseLog",
                newSchema: "Madfoatcom");

            migrationBuilder.RenameTable(
                name: "AppAccessChannelLookup",
                newName: "AccessChannelLookup",
                newSchema: "Lookups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThresholdLookup",
                schema: "Lookups",
                table: "ThresholdLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeverityLookup",
                schema: "Lookups",
                table: "SeverityLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypeLookup",
                schema: "Lookups",
                table: "ServiceTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessStatusLookup",
                schema: "Lookups",
                table: "ProcessStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrepaidValidationConfig",
                schema: "Orange",
                table: "PrepaidValidationConfig",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrepaidCategoryLookup",
                schema: "Lookups",
                table: "PrepaidCategoryLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeLookup",
                schema: "Lookups",
                table: "PaymentTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentStatusLookup",
                schema: "Lookups",
                table: "PaymentStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentSourceLookup",
                schema: "Lookups",
                table: "PaymentSourceLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethodLookup",
                schema: "Lookups",
                table: "PaymentMethodLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCurrencyLookup",
                schema: "Lookups",
                table: "PaymentCurrencyLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrangeBillPullServiceConfiguration",
                schema: "Orange",
                table: "OrangeBillPullServiceConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrangeBillPaymentNotificationConfiguration",
                schema: "Orange",
                table: "OrangeBillPaymentNotificationConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationTypeLookup",
                schema: "Lookups",
                table: "OperationTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodTypeLookup",
                schema: "Lookups",
                table: "MethodTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageEncodingLookup",
                schema: "Lookups",
                table: "MessageEncodingLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MadfoatcomResponse",
                schema: "Madfoatcom",
                table: "MadfoatcomResponse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MadfoatcomRequest",
                schema: "Madfoatcom",
                table: "MadfoatcomRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageIsoNameLookup",
                schema: "Lookups",
                table: "LanguageIsoNameLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailRecipientSendingStatusLookup",
                schema: "Lookups",
                table: "EmailRecipientSendingStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharSetLookup",
                schema: "Lookups",
                table: "CharSetLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillTypeLookup",
                schema: "Lookups",
                table: "BillTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillStatusLookup",
                schema: "Lookups",
                table: "BillStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillingStatusLookup",
                schema: "Lookups",
                table: "BillingStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiRequestResponseLog",
                schema: "Madfoatcom",
                table: "ApiRequestResponseLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessChannelLookup",
                schema: "Lookups",
                table: "AccessChannelLookup",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThresholdLookup",
                schema: "Lookups",
                table: "ThresholdLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeverityLookup",
                schema: "Lookups",
                table: "SeverityLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypeLookup",
                schema: "Lookups",
                table: "ServiceTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessStatusLookup",
                schema: "Lookups",
                table: "ProcessStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrepaidValidationConfig",
                schema: "Orange",
                table: "PrepaidValidationConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrepaidCategoryLookup",
                schema: "Lookups",
                table: "PrepaidCategoryLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeLookup",
                schema: "Lookups",
                table: "PaymentTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentStatusLookup",
                schema: "Lookups",
                table: "PaymentStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentSourceLookup",
                schema: "Lookups",
                table: "PaymentSourceLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethodLookup",
                schema: "Lookups",
                table: "PaymentMethodLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCurrencyLookup",
                schema: "Lookups",
                table: "PaymentCurrencyLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrangeBillPullServiceConfiguration",
                schema: "Orange",
                table: "OrangeBillPullServiceConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrangeBillPaymentNotificationConfiguration",
                schema: "Orange",
                table: "OrangeBillPaymentNotificationConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationTypeLookup",
                schema: "Lookups",
                table: "OperationTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodTypeLookup",
                schema: "Lookups",
                table: "MethodTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageEncodingLookup",
                schema: "Lookups",
                table: "MessageEncodingLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MadfoatcomResponse",
                schema: "Madfoatcom",
                table: "MadfoatcomResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MadfoatcomRequest",
                schema: "Madfoatcom",
                table: "MadfoatcomRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageIsoNameLookup",
                schema: "Lookups",
                table: "LanguageIsoNameLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailRecipientSendingStatusLookup",
                schema: "Lookups",
                table: "EmailRecipientSendingStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharSetLookup",
                schema: "Lookups",
                table: "CharSetLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillTypeLookup",
                schema: "Lookups",
                table: "BillTypeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillStatusLookup",
                schema: "Lookups",
                table: "BillStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillingStatusLookup",
                schema: "Lookups",
                table: "BillingStatusLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiRequestResponseLog",
                schema: "Madfoatcom",
                table: "ApiRequestResponseLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessChannelLookup",
                schema: "Lookups",
                table: "AccessChannelLookup");

            migrationBuilder.RenameTable(
                name: "ThresholdLookup",
                schema: "Lookups",
                newName: "AppThresholdLookup");

            migrationBuilder.RenameTable(
                name: "SeverityLookup",
                schema: "Lookups",
                newName: "AppSeverityLookup");

            migrationBuilder.RenameTable(
                name: "ServiceTypeLookup",
                schema: "Lookups",
                newName: "AppServiceTypeLookup");

            migrationBuilder.RenameTable(
                name: "ProcessStatusLookup",
                schema: "Lookups",
                newName: "AppProcessStatusLookup");

            migrationBuilder.RenameTable(
                name: "PrepaidValidationConfig",
                schema: "Orange",
                newName: "AppPrepaidValidationConfig");

            migrationBuilder.RenameTable(
                name: "PrepaidCategoryLookup",
                schema: "Lookups",
                newName: "AppPrepaidCategoryLookup");

            migrationBuilder.RenameTable(
                name: "PaymentTypeLookup",
                schema: "Lookups",
                newName: "AppPaymentTypeLookup");

            migrationBuilder.RenameTable(
                name: "PaymentStatusLookup",
                schema: "Lookups",
                newName: "AppPaymentStatusLookup");

            migrationBuilder.RenameTable(
                name: "PaymentSourceLookup",
                schema: "Lookups",
                newName: "AppPaymentSourceLookup");

            migrationBuilder.RenameTable(
                name: "PaymentMethodLookup",
                schema: "Lookups",
                newName: "AppPaymentMethodLookup");

            migrationBuilder.RenameTable(
                name: "PaymentCurrencyLookup",
                schema: "Lookups",
                newName: "AppPaymentCurrencyLookup");

            migrationBuilder.RenameTable(
                name: "OrangeBillPullServiceConfiguration",
                schema: "Orange",
                newName: "AppOrangeBillPullServiceConfiguration");

            migrationBuilder.RenameTable(
                name: "OrangeBillPaymentNotificationConfiguration",
                schema: "Orange",
                newName: "AppOrangeBillPaymentNotificationConfiguration");

            migrationBuilder.RenameTable(
                name: "OperationTypeLookup",
                schema: "Lookups",
                newName: "AppOperationTypeLookup");

            migrationBuilder.RenameTable(
                name: "MethodTypeLookup",
                schema: "Lookups",
                newName: "AppMethodTypeLookup");

            migrationBuilder.RenameTable(
                name: "MessageEncodingLookup",
                schema: "Lookups",
                newName: "AppMessageEncodingLookup");

            migrationBuilder.RenameTable(
                name: "MadfoatcomResponse",
                schema: "Madfoatcom",
                newName: "AppMadfoatcomResponse");

            migrationBuilder.RenameTable(
                name: "MadfoatcomRequest",
                schema: "Madfoatcom",
                newName: "AppMadfoatcomRequest");

            migrationBuilder.RenameTable(
                name: "LanguageIsoNameLookup",
                schema: "Lookups",
                newName: "AppLanguageIsoNameLookup");

            migrationBuilder.RenameTable(
                name: "EmailRecipientSendingStatusLookup",
                schema: "Lookups",
                newName: "AppEmailRecipientSendingStatusLookup");

            migrationBuilder.RenameTable(
                name: "CharSetLookup",
                schema: "Lookups",
                newName: "AppCharSetLookup");

            migrationBuilder.RenameTable(
                name: "BillTypeLookup",
                schema: "Lookups",
                newName: "AppBillTypeLookup");

            migrationBuilder.RenameTable(
                name: "BillStatusLookup",
                schema: "Lookups",
                newName: "AppBillStatusLookup");

            migrationBuilder.RenameTable(
                name: "BillingStatusLookup",
                schema: "Lookups",
                newName: "AppBillingStatusLookup");

            migrationBuilder.RenameTable(
                name: "ApiRequestResponseLog",
                schema: "Madfoatcom",
                newName: "AppApiRequestResponseLog");

            migrationBuilder.RenameTable(
                name: "AccessChannelLookup",
                schema: "Lookups",
                newName: "AppAccessChannelLookup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppThresholdLookup",
                table: "AppThresholdLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSeverityLookup",
                table: "AppSeverityLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppServiceTypeLookup",
                table: "AppServiceTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProcessStatusLookup",
                table: "AppProcessStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPrepaidValidationConfig",
                table: "AppPrepaidValidationConfig",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPrepaidCategoryLookup",
                table: "AppPrepaidCategoryLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPaymentTypeLookup",
                table: "AppPaymentTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPaymentStatusLookup",
                table: "AppPaymentStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPaymentSourceLookup",
                table: "AppPaymentSourceLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPaymentMethodLookup",
                table: "AppPaymentMethodLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPaymentCurrencyLookup",
                table: "AppPaymentCurrencyLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrangeBillPullServiceConfiguration",
                table: "AppOrangeBillPullServiceConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrangeBillPaymentNotificationConfiguration",
                table: "AppOrangeBillPaymentNotificationConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOperationTypeLookup",
                table: "AppOperationTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMethodTypeLookup",
                table: "AppMethodTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMessageEncodingLookup",
                table: "AppMessageEncodingLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMadfoatcomResponse",
                table: "AppMadfoatcomResponse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMadfoatcomRequest",
                table: "AppMadfoatcomRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLanguageIsoNameLookup",
                table: "AppLanguageIsoNameLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEmailRecipientSendingStatusLookup",
                table: "AppEmailRecipientSendingStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCharSetLookup",
                table: "AppCharSetLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBillTypeLookup",
                table: "AppBillTypeLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBillStatusLookup",
                table: "AppBillStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBillingStatusLookup",
                table: "AppBillingStatusLookup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppApiRequestResponseLog",
                table: "AppApiRequestResponseLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppAccessChannelLookup",
                table: "AppAccessChannelLookup",
                column: "Id");
        }
    }
}
