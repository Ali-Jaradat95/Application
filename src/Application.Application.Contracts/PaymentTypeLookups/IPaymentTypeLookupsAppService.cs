using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PaymentTypeLookups
{
    public partial interface IPaymentTypeLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentTypeLookupDto>> GetListAsync(GetPaymentTypeLookupsInput input);

        Task<PaymentTypeLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentTypeLookupDto> CreateAsync(PaymentTypeLookupCreateDto input);

        Task<PaymentTypeLookupDto> UpdateAsync(int id, PaymentTypeLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentTypeLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}