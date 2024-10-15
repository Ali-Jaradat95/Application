using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.MadfoatcomRequests
{
    public partial interface IMadfoatcomRequestsAppService : IApplicationService
    {
        Task<PagedResultDto<MadfoatcomRequestDto>> GetListAsync(GetMadfoatcomRequestsInput input);

        Task<MadfoatcomRequestDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<MadfoatcomRequestDto> CreateAsync(MadfoatcomRequestCreateDto input);

        Task<MadfoatcomRequestDto> UpdateAsync(int id, MadfoatcomRequestUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MadfoatcomRequestExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}