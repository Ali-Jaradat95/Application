using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PaymentStatusLookups
{
    public abstract class PaymentStatusLookupManagerBase : DomainService
    {
        protected IPaymentStatusLookupRepository _paymentStatusLookupRepository;

        public PaymentStatusLookupManagerBase(IPaymentStatusLookupRepository paymentStatusLookupRepository)
        {
            _paymentStatusLookupRepository = paymentStatusLookupRepository;
        }

        public virtual async Task<PaymentStatusLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentStatusLookup = new PaymentStatusLookup(

             code, name, description
             );

            return await _paymentStatusLookupRepository.InsertAsync(paymentStatusLookup);
        }

        public virtual async Task<PaymentStatusLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentStatusLookup = await _paymentStatusLookupRepository.GetAsync(id);

            paymentStatusLookup.Code = code;
            paymentStatusLookup.Name = name;
            paymentStatusLookup.Description = description;

            paymentStatusLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _paymentStatusLookupRepository.UpdateAsync(paymentStatusLookup);
        }

    }
}