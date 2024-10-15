using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.SeverityLookups
{
    public partial interface ISeverityLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<SeverityLookupDto>> GetListAsync(GetSeverityLookupsInput input);

        Task<SeverityLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<SeverityLookupDto> CreateAsync(SeverityLookupCreateDto input);

        Task<SeverityLookupDto> UpdateAsync(int id, SeverityLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SeverityLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}