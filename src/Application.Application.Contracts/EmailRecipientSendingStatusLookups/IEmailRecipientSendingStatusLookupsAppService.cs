using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.EmailRecipientSendingStatusLookups
{
    public partial interface IEmailRecipientSendingStatusLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<EmailRecipientSendingStatusLookupDto>> GetListAsync(GetEmailRecipientSendingStatusLookupsInput input);

        Task<EmailRecipientSendingStatusLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<EmailRecipientSendingStatusLookupDto> CreateAsync(EmailRecipientSendingStatusLookupCreateDto input);

        Task<EmailRecipientSendingStatusLookupDto> UpdateAsync(int id, EmailRecipientSendingStatusLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(EmailRecipientSendingStatusLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}