using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PrepaidCategoryLookups
{
    public partial interface IPrepaidCategoryLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PrepaidCategoryLookupDto>> GetListAsync(GetPrepaidCategoryLookupsInput input);

        Task<PrepaidCategoryLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PrepaidCategoryLookupDto> CreateAsync(PrepaidCategoryLookupCreateDto input);

        Task<PrepaidCategoryLookupDto> UpdateAsync(int id, PrepaidCategoryLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PrepaidCategoryLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}