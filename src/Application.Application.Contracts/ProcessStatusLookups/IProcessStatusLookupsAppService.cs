using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.ProcessStatusLookups
{
    public partial interface IProcessStatusLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<ProcessStatusLookupDto>> GetListAsync(GetProcessStatusLookupsInput input);

        Task<ProcessStatusLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ProcessStatusLookupDto> CreateAsync(ProcessStatusLookupCreateDto input);

        Task<ProcessStatusLookupDto> UpdateAsync(int id, ProcessStatusLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ProcessStatusLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}