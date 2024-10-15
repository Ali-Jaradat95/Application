using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.ThresholdLookups
{
    public partial interface IThresholdLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<ThresholdLookupDto>> GetListAsync(GetThresholdLookupsInput input);

        Task<ThresholdLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ThresholdLookupDto> CreateAsync(ThresholdLookupCreateDto input);

        Task<ThresholdLookupDto> UpdateAsync(int id, ThresholdLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ThresholdLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}