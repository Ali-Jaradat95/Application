using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public partial interface IOrangeBillPaymentNotificationConfigurationsAppService : IApplicationService
    {
        Task<PagedResultDto<OrangeBillPaymentNotificationConfigurationDto>> GetListAsync(GetOrangeBillPaymentNotificationConfigurationsInput input);

        Task<OrangeBillPaymentNotificationConfigurationDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<OrangeBillPaymentNotificationConfigurationDto> CreateAsync(OrangeBillPaymentNotificationConfigurationCreateDto input);

        Task<OrangeBillPaymentNotificationConfigurationDto> UpdateAsync(int id, OrangeBillPaymentNotificationConfigurationUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(OrangeBillPaymentNotificationConfigurationExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}