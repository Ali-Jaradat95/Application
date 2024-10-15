using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.MadfoatcomResponses
{
    public partial interface IMadfoatcomResponsesAppService : IApplicationService
    {
        Task<PagedResultDto<MadfoatcomResponseDto>> GetListAsync(GetMadfoatcomResponsesInput input);

        Task<MadfoatcomResponseDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<MadfoatcomResponseDto> CreateAsync(MadfoatcomResponseCreateDto input);

        Task<MadfoatcomResponseDto> UpdateAsync(int id, MadfoatcomResponseUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MadfoatcomResponseExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}