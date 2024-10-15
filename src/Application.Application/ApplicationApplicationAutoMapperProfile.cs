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
using System;
using Application.Shared;
using Volo.Abp.AutoMapper;
using Application.AccessChannelLookups;
using AutoMapper;

namespace Application;

public class ApplicationApplicationAutoMapperProfile : Profile
{
    public ApplicationApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<AccessChannelLookup, AccessChannelLookupDto>();
        CreateMap<AccessChannelLookup, AccessChannelLookupExcelDto>();

        CreateMap<BillingStatusLookup, BillingStatusLookupDto>();
        CreateMap<BillingStatusLookup, BillingStatusLookupExcelDto>();

        CreateMap<BillStatusLookup, BillStatusLookupDto>();
        CreateMap<BillStatusLookup, BillStatusLookupExcelDto>();

        CreateMap<BillTypeLookup, BillTypeLookupDto>();
        CreateMap<BillTypeLookup, BillTypeLookupExcelDto>();

        CreateMap<CharSetLookup, CharSetLookupDto>();
        CreateMap<CharSetLookup, CharSetLookupExcelDto>();

        CreateMap<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookupDto>();
        CreateMap<EmailRecipientSendingStatusLookup, EmailRecipientSendingStatusLookupExcelDto>();

        CreateMap<LanguageIsoNameLookup, LanguageIsoNameLookupDto>();
        CreateMap<LanguageIsoNameLookup, LanguageIsoNameLookupExcelDto>();

        CreateMap<MessageEncodingLookup, MessageEncodingLookupDto>();
        CreateMap<MessageEncodingLookup, MessageEncodingLookupExcelDto>();

        CreateMap<MethodTypeLookup, MethodTypeLookupDto>();
        CreateMap<MethodTypeLookup, MethodTypeLookupExcelDto>();

        CreateMap<OperationTypeLookup, OperationTypeLookupDto>();
        CreateMap<OperationTypeLookup, OperationTypeLookupExcelDto>();

        CreateMap<PaymentCurrencyLookup, PaymentCurrencyLookupDto>();
        CreateMap<PaymentCurrencyLookup, PaymentCurrencyLookupExcelDto>();

        CreateMap<PaymentMethodLookup, PaymentMethodLookupDto>();
        CreateMap<PaymentMethodLookup, PaymentMethodLookupExcelDto>();

        CreateMap<PaymentSourceLookup, PaymentSourceLookupDto>();
        CreateMap<PaymentSourceLookup, PaymentSourceLookupExcelDto>();

        CreateMap<PaymentStatusLookup, PaymentStatusLookupDto>();
        CreateMap<PaymentStatusLookup, PaymentStatusLookupExcelDto>();

        CreateMap<PaymentTypeLookup, PaymentTypeLookupDto>();
        CreateMap<PaymentTypeLookup, PaymentTypeLookupExcelDto>();

        CreateMap<PrepaidCategoryLookup, PrepaidCategoryLookupDto>();
        CreateMap<PrepaidCategoryLookup, PrepaidCategoryLookupExcelDto>();

        CreateMap<ProcessStatusLookup, ProcessStatusLookupDto>();
        CreateMap<ProcessStatusLookup, ProcessStatusLookupExcelDto>();

        CreateMap<ServiceTypeLookup, ServiceTypeLookupDto>();
        CreateMap<ServiceTypeLookup, ServiceTypeLookupExcelDto>();

        CreateMap<SeverityLookup, SeverityLookupDto>();
        CreateMap<SeverityLookup, SeverityLookupExcelDto>();

        CreateMap<ThresholdLookup, ThresholdLookupDto>();
        CreateMap<ThresholdLookup, ThresholdLookupExcelDto>();

        CreateMap<ApiRequestResponseLog, ApiRequestResponseLogDto>();
        CreateMap<ApiRequestResponseLog, ApiRequestResponseLogExcelDto>();

        CreateMap<MadfoatcomRequest, MadfoatcomRequestDto>();
        CreateMap<MadfoatcomRequest, MadfoatcomRequestExcelDto>();

        CreateMap<MadfoatcomResponse, MadfoatcomResponseDto>();
        CreateMap<MadfoatcomResponse, MadfoatcomResponseExcelDto>();

        CreateMap<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurationDto>();
        CreateMap<OrangeBillPaymentNotificationConfiguration, OrangeBillPaymentNotificationConfigurationExcelDto>();

        CreateMap<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurationDto>();
        CreateMap<OrangeBillPullServiceConfiguration, OrangeBillPullServiceConfigurationExcelDto>();

        CreateMap<PrepaidValidationConfig, PrepaidValidationConfigDto>();
        CreateMap<PrepaidValidationConfig, PrepaidValidationConfigExcelDto>();
    }
}