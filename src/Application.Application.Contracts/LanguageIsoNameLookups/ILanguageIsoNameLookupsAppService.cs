using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.LanguageIsoNameLookups
{
    public partial interface ILanguageIsoNameLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<LanguageIsoNameLookupDto>> GetListAsync(GetLanguageIsoNameLookupsInput input);

        Task<LanguageIsoNameLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<LanguageIsoNameLookupDto> CreateAsync(LanguageIsoNameLookupCreateDto input);

        Task<LanguageIsoNameLookupDto> UpdateAsync(int id, LanguageIsoNameLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(LanguageIsoNameLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}