using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.ServiceTypeLookups
{
    public partial interface IServiceTypeLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<ServiceTypeLookupDto>> GetListAsync(GetServiceTypeLookupsInput input);

        Task<ServiceTypeLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ServiceTypeLookupDto> CreateAsync(ServiceTypeLookupCreateDto input);

        Task<ServiceTypeLookupDto> UpdateAsync(int id, ServiceTypeLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ServiceTypeLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}