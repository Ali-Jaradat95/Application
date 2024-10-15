using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PaymentSourceLookups
{
    public partial interface IPaymentSourceLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentSourceLookupDto>> GetListAsync(GetPaymentSourceLookupsInput input);

        Task<PaymentSourceLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentSourceLookupDto> CreateAsync(PaymentSourceLookupCreateDto input);

        Task<PaymentSourceLookupDto> UpdateAsync(int id, PaymentSourceLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentSourceLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}