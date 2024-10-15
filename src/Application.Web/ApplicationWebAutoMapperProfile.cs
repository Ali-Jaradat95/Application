using Application.Web.Pages.PrepaidValidationConfigs;
using Application.PrepaidValidationConfigs;
using Application.Web.Pages.OrangeBillPullServiceConfigurations;
using Application.OrangeBillPullServiceConfigurations;
using Application.Web.Pages.OrangeBillPaymentNotificationConfigurations;
using Application.OrangeBillPaymentNotificationConfigurations;
using Application.Web.Pages.MadfoatcomResponses;
using Application.MadfoatcomResponses;
using Application.Web.Pages.MadfoatcomRequests;
using Application.MadfoatcomRequests;
using Application.Web.Pages.ApiRequestResponseLogs;
using Application.ApiRequestResponseLogs;
using Application.Web.Pages.ThresholdLookups;
using Application.ThresholdLookups;
using Application.Web.Pages.SeverityLookups;
using Application.SeverityLookups;
using Application.Web.Pages.ServiceTypeLookups;
using Application.ServiceTypeLookups;
using Application.Web.Pages.ProcessStatusLookups;
using Application.ProcessStatusLookups;
using Application.Web.Pages.PrepaidCategoryLookups;
using Application.PrepaidCategoryLookups;
using Application.Web.Pages.PaymentTypeLookups;
using Application.PaymentTypeLookups;
using Application.Web.Pages.PaymentStatusLookups;
using Application.PaymentStatusLookups;
using Application.Web.Pages.PaymentSourceLookups;
using Application.PaymentSourceLookups;
using Application.Web.Pages.PaymentMethodLookups;
using Application.PaymentMethodLookups;
using Application.Web.Pages.PaymentCurrencyLookups;
using Application.PaymentCurrencyLookups;
using Application.Web.Pages.OperationTypeLookups;
using Application.OperationTypeLookups;
using Application.Web.Pages.MethodTypeLookups;
using Application.MethodTypeLookups;
using Application.Web.Pages.MessageEncodingLookups;
using Application.MessageEncodingLookups;
using Application.Web.Pages.LanguageIsoNameLookups;
using Application.LanguageIsoNameLookups;
using Application.Web.Pages.EmailRecipientSendingStatusLookups;
using Application.EmailRecipientSendingStatusLookups;
using Application.Web.Pages.CharSetLookups;
using Application.CharSetLookups;
using Application.Web.Pages.BillTypeLookups;
using Application.BillTypeLookups;
using Application.Web.Pages.BillStatusLookups;
using Application.BillStatusLookups;
using Application.Web.Pages.BillingStatusLookups;
using Application.BillingStatusLookups;
using Application.Web.Pages.AccessChannelLookups;
using Volo.Abp.AutoMapper;
using Application.AccessChannelLookups;
using AutoMapper;

namespace Application.Web;

public class ApplicationWebAutoMapperProfile : Profile
{
    public ApplicationWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project

        CreateMap<AccessChannelLookupDto, AccessChannelLookupUpdateViewModel>();
        CreateMap<AccessChannelLookupUpdateViewModel, AccessChannelLookupUpdateDto>();
        CreateMap<AccessChannelLookupCreateViewModel, AccessChannelLookupCreateDto>();

        CreateMap<BillingStatusLookupDto, BillingStatusLookupUpdateViewModel>();
        CreateMap<BillingStatusLookupUpdateViewModel, BillingStatusLookupUpdateDto>();
        CreateMap<BillingStatusLookupCreateViewModel, BillingStatusLookupCreateDto>();

        CreateMap<BillStatusLookupDto, BillStatusLookupUpdateViewModel>();
        CreateMap<BillStatusLookupUpdateViewModel, BillStatusLookupUpdateDto>();
        CreateMap<BillStatusLookupCreateViewModel, BillStatusLookupCreateDto>();

        CreateMap<BillTypeLookupDto, BillTypeLookupUpdateViewModel>();
        CreateMap<BillTypeLookupUpdateViewModel, BillTypeLookupUpdateDto>();
        CreateMap<BillTypeLookupCreateViewModel, BillTypeLookupCreateDto>();

        CreateMap<CharSetLookupDto, CharSetLookupUpdateViewModel>();
        CreateMap<CharSetLookupUpdateViewModel, CharSetLookupUpdateDto>();
        CreateMap<CharSetLookupCreateViewModel, CharSetLookupCreateDto>();

        CreateMap<EmailRecipientSendingStatusLookupDto, EmailRecipientSendingStatusLookupUpdateViewModel>();
        CreateMap<EmailRecipientSendingStatusLookupUpdateViewModel, EmailRecipientSendingStatusLookupUpdateDto>();
        CreateMap<EmailRecipientSendingStatusLookupCreateViewModel, EmailRecipientSendingStatusLookupCreateDto>();

        CreateMap<LanguageIsoNameLookupDto, LanguageIsoNameLookupUpdateViewModel>();
        CreateMap<LanguageIsoNameLookupUpdateViewModel, LanguageIsoNameLookupUpdateDto>();
        CreateMap<LanguageIsoNameLookupCreateViewModel, LanguageIsoNameLookupCreateDto>();

        CreateMap<MessageEncodingLookupDto, MessageEncodingLookupUpdateViewModel>();
        CreateMap<MessageEncodingLookupUpdateViewModel, MessageEncodingLookupUpdateDto>();
        CreateMap<MessageEncodingLookupCreateViewModel, MessageEncodingLookupCreateDto>();

        CreateMap<MethodTypeLookupDto, MethodTypeLookupUpdateViewModel>();
        CreateMap<MethodTypeLookupUpdateViewModel, MethodTypeLookupUpdateDto>();
        CreateMap<MethodTypeLookupCreateViewModel, MethodTypeLookupCreateDto>();

        CreateMap<OperationTypeLookupDto, OperationTypeLookupUpdateViewModel>();
        CreateMap<OperationTypeLookupUpdateViewModel, OperationTypeLookupUpdateDto>();
        CreateMap<OperationTypeLookupCreateViewModel, OperationTypeLookupCreateDto>();

        CreateMap<PaymentCurrencyLookupDto, PaymentCurrencyLookupUpdateViewModel>();
        CreateMap<PaymentCurrencyLookupUpdateViewModel, PaymentCurrencyLookupUpdateDto>();
        CreateMap<PaymentCurrencyLookupCreateViewModel, PaymentCurrencyLookupCreateDto>();

        CreateMap<PaymentMethodLookupDto, PaymentMethodLookupUpdateViewModel>();
        CreateMap<PaymentMethodLookupUpdateViewModel, PaymentMethodLookupUpdateDto>();
        CreateMap<PaymentMethodLookupCreateViewModel, PaymentMethodLookupCreateDto>();

        CreateMap<PaymentSourceLookupDto, PaymentSourceLookupUpdateViewModel>();
        CreateMap<PaymentSourceLookupUpdateViewModel, PaymentSourceLookupUpdateDto>();
        CreateMap<PaymentSourceLookupCreateViewModel, PaymentSourceLookupCreateDto>();

        CreateMap<PaymentStatusLookupDto, PaymentStatusLookupUpdateViewModel>();
        CreateMap<PaymentStatusLookupUpdateViewModel, PaymentStatusLookupUpdateDto>();
        CreateMap<PaymentStatusLookupCreateViewModel, PaymentStatusLookupCreateDto>();

        CreateMap<PaymentTypeLookupDto, PaymentTypeLookupUpdateViewModel>();
        CreateMap<PaymentTypeLookupUpdateViewModel, PaymentTypeLookupUpdateDto>();
        CreateMap<PaymentTypeLookupCreateViewModel, PaymentTypeLookupCreateDto>();

        CreateMap<PrepaidCategoryLookupDto, PrepaidCategoryLookupUpdateViewModel>();
        CreateMap<PrepaidCategoryLookupUpdateViewModel, PrepaidCategoryLookupUpdateDto>();
        CreateMap<PrepaidCategoryLookupCreateViewModel, PrepaidCategoryLookupCreateDto>();

        CreateMap<ProcessStatusLookupDto, ProcessStatusLookupUpdateViewModel>();
        CreateMap<ProcessStatusLookupUpdateViewModel, ProcessStatusLookupUpdateDto>();
        CreateMap<ProcessStatusLookupCreateViewModel, ProcessStatusLookupCreateDto>();

        CreateMap<ServiceTypeLookupDto, ServiceTypeLookupUpdateViewModel>();
        CreateMap<ServiceTypeLookupUpdateViewModel, ServiceTypeLookupUpdateDto>();
        CreateMap<ServiceTypeLookupCreateViewModel, ServiceTypeLookupCreateDto>();

        CreateMap<SeverityLookupDto, SeverityLookupUpdateViewModel>();
        CreateMap<SeverityLookupUpdateViewModel, SeverityLookupUpdateDto>();
        CreateMap<SeverityLookupCreateViewModel, SeverityLookupCreateDto>();

        CreateMap<ThresholdLookupDto, ThresholdLookupUpdateViewModel>();
        CreateMap<ThresholdLookupUpdateViewModel, ThresholdLookupUpdateDto>();
        CreateMap<ThresholdLookupCreateViewModel, ThresholdLookupCreateDto>();

        CreateMap<ApiRequestResponseLogDto, ApiRequestResponseLogUpdateViewModel>();
        CreateMap<ApiRequestResponseLogUpdateViewModel, ApiRequestResponseLogUpdateDto>();
        CreateMap<ApiRequestResponseLogCreateViewModel, ApiRequestResponseLogCreateDto>();

        CreateMap<MadfoatcomRequestDto, MadfoatcomRequestUpdateViewModel>();
        CreateMap<MadfoatcomRequestUpdateViewModel, MadfoatcomRequestUpdateDto>();
        CreateMap<MadfoatcomRequestCreateViewModel, MadfoatcomRequestCreateDto>();

        CreateMap<MadfoatcomResponseDto, MadfoatcomResponseUpdateViewModel>();
        CreateMap<MadfoatcomResponseUpdateViewModel, MadfoatcomResponseUpdateDto>();
        CreateMap<MadfoatcomResponseCreateViewModel, MadfoatcomResponseCreateDto>();

        CreateMap<OrangeBillPaymentNotificationConfigurationDto, OrangeBillPaymentNotificationConfigurationUpdateViewModel>();
        CreateMap<OrangeBillPaymentNotificationConfigurationUpdateViewModel, OrangeBillPaymentNotificationConfigurationUpdateDto>();
        CreateMap<OrangeBillPaymentNotificationConfigurationCreateViewModel, OrangeBillPaymentNotificationConfigurationCreateDto>();

        CreateMap<OrangeBillPullServiceConfigurationDto, OrangeBillPullServiceConfigurationUpdateViewModel>();
        CreateMap<OrangeBillPullServiceConfigurationUpdateViewModel, OrangeBillPullServiceConfigurationUpdateDto>();
        CreateMap<OrangeBillPullServiceConfigurationCreateViewModel, OrangeBillPullServiceConfigurationCreateDto>();

        CreateMap<PrepaidValidationConfigDto, PrepaidValidationConfigUpdateViewModel>();
        CreateMap<PrepaidValidationConfigUpdateViewModel, PrepaidValidationConfigUpdateDto>();
        CreateMap<PrepaidValidationConfigCreateViewModel, PrepaidValidationConfigCreateDto>();
    }
}