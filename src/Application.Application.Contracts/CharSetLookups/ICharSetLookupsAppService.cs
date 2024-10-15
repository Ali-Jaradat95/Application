using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.CharSetLookups
{
    public partial interface ICharSetLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<CharSetLookupDto>> GetListAsync(GetCharSetLookupsInput input);

        Task<CharSetLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<CharSetLookupDto> CreateAsync(CharSetLookupCreateDto input);

        Task<CharSetLookupDto> UpdateAsync(int id, CharSetLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CharSetLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}