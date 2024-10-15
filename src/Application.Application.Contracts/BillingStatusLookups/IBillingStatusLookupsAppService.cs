using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.BillingStatusLookups
{
    public partial interface IBillingStatusLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<BillingStatusLookupDto>> GetListAsync(GetBillingStatusLookupsInput input);

        Task<BillingStatusLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<BillingStatusLookupDto> CreateAsync(BillingStatusLookupCreateDto input);

        Task<BillingStatusLookupDto> UpdateAsync(int id, BillingStatusLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillingStatusLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}