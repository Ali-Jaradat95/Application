using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.AccessChannelLookups
{
    public partial interface IAccessChannelLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<AccessChannelLookupDto>> GetListAsync(GetAccessChannelLookupsInput input);

        Task<AccessChannelLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AccessChannelLookupDto> CreateAsync(AccessChannelLookupCreateDto input);

        Task<AccessChannelLookupDto> UpdateAsync(int id, AccessChannelLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(AccessChannelLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}