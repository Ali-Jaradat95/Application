using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PaymentCurrencyLookups
{
    public partial interface IPaymentCurrencyLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentCurrencyLookupDto>> GetListAsync(GetPaymentCurrencyLookupsInput input);

        Task<PaymentCurrencyLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentCurrencyLookupDto> CreateAsync(PaymentCurrencyLookupCreateDto input);

        Task<PaymentCurrencyLookupDto> UpdateAsync(int id, PaymentCurrencyLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentCurrencyLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}