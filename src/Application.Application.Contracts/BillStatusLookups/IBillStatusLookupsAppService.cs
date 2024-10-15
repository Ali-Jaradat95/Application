using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.BillStatusLookups
{
    public partial interface IBillStatusLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<BillStatusLookupDto>> GetListAsync(GetBillStatusLookupsInput input);

        Task<BillStatusLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<BillStatusLookupDto> CreateAsync(BillStatusLookupCreateDto input);

        Task<BillStatusLookupDto> UpdateAsync(int id, BillStatusLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillStatusLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}