using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.OperationTypeLookups
{
    public partial interface IOperationTypeLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<OperationTypeLookupDto>> GetListAsync(GetOperationTypeLookupsInput input);

        Task<OperationTypeLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<OperationTypeLookupDto> CreateAsync(OperationTypeLookupCreateDto input);

        Task<OperationTypeLookupDto> UpdateAsync(int id, OperationTypeLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(OperationTypeLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}