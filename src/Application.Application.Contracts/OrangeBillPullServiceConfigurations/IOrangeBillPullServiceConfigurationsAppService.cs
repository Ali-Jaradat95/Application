using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.OrangeBillPullServiceConfigurations
{
    public partial interface IOrangeBillPullServiceConfigurationsAppService : IApplicationService
    {
        Task<PagedResultDto<OrangeBillPullServiceConfigurationDto>> GetListAsync(GetOrangeBillPullServiceConfigurationsInput input);

        Task<OrangeBillPullServiceConfigurationDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<OrangeBillPullServiceConfigurationDto> CreateAsync(OrangeBillPullServiceConfigurationCreateDto input);

        Task<OrangeBillPullServiceConfigurationDto> UpdateAsync(int id, OrangeBillPullServiceConfigurationUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(OrangeBillPullServiceConfigurationExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}