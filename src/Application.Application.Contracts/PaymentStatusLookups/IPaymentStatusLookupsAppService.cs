using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Application.Shared;

namespace Application.PaymentStatusLookups
{
    public partial interface IPaymentStatusLookupsAppService : IApplicationService
    {
        Task<PagedResultDto<PaymentStatusLookupDto>> GetListAsync(GetPaymentStatusLookupsInput input);

        Task<PaymentStatusLookupDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentStatusLookupDto> CreateAsync(PaymentStatusLookupCreateDto input);

        Task<PaymentStatusLookupDto> UpdateAsync(int id, PaymentStatusLookupUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PaymentStatusLookupExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}