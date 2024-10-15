using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.MethodTypeLookups
{
    public partial interface IMethodTypeLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<MethodTypeLookupDto>> GetListAsync(GetMethodTypeLookupsInput input);

        Task<MethodTypeLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<MethodTypeLookupDto> CreateAsync(MethodTypeLookupCreateDto input);

        Task<MethodTypeLookupDto> UpdateAsync(int id, MethodTypeLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MethodTypeLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}