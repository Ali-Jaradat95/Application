using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.BillTypeLookups
{
    public partial interface IBillTypeLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<BillTypeLookupDto>> GetListAsync(GetBillTypeLookupsInput input);

        Task<BillTypeLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<BillTypeLookupDto> CreateAsync(BillTypeLookupCreateDto input);

        Task<BillTypeLookupDto> UpdateAsync(int id, BillTypeLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(BillTypeLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}