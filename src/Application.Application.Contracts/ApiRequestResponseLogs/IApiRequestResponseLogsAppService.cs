using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.ApiRequestResponseLogs
{
    public partial interface IApiRequestResponseLogsAppService : IApplicationService
    {
        Task<PagedResultDto<ApiRequestResponseLogDto>> GetListAsync(GetApiRequestResponseLogsInput input);

        Task<ApiRequestResponseLogDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ApiRequestResponseLogDto> CreateAsync(ApiRequestResponseLogCreateDto input);

        Task<ApiRequestResponseLogDto> UpdateAsync(int id, ApiRequestResponseLogUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ApiRequestResponseLogExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}