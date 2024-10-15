using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.MessageEncodingLookups
{
    public partial interface IMessageEncodingLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<MessageEncodingLookupDto>> GetListAsync(GetMessageEncodingLookupsInput input);

        Task<MessageEncodingLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<MessageEncodingLookupDto> CreateAsync(MessageEncodingLookupCreateDto input);

        Task<MessageEncodingLookupDto> UpdateAsync(int id, MessageEncodingLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MessageEncodingLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}