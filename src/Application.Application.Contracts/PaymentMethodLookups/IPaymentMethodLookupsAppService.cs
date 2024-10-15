using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PaymentMethodLookups
{
    public partial interface IPaymentMethodLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentMethodLookupDto>> GetListAsync(GetPaymentMethodLookupsInput input);

        Task<PaymentMethodLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentMethodLookupDto> CreateAsync(PaymentMethodLookupCreateDto input);

        Task<PaymentMethodLookupDto> UpdateAsync(int id, PaymentMethodLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentMethodLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}