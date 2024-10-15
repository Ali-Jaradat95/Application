using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PrepaidValidationConfigs
{
    public partial interface IPrepaidValidationConfigsAppService : IApplicationService
    {
        Task<PagedResultDto<PrepaidValidationConfigDto>> GetListAsync(GetPrepaidValidationConfigsInput input);

        Task<PrepaidValidationConfigDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PrepaidValidationConfigDto> CreateAsync(PrepaidValidationConfigCreateDto input);

        Task<PrepaidValidationConfigDto> UpdateAsync(int id, PrepaidValidationConfigUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PrepaidValidationConfigExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}