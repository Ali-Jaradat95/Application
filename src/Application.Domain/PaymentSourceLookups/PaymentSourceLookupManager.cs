using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PaymentSourceLookups
{
    public abstract class PaymentSourceLookupManagerBase : DomainService
    {
        protected IPaymentSourceLookupRepository _paymentSourceLookupRepository;

        public PaymentSourceLookupManagerBase(IPaymentSourceLookupRepository paymentSourceLookupRepository)
        {
            _paymentSourceLookupRepository = paymentSourceLookupRepository;
        }

        public virtual async Task<PaymentSourceLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentSourceLookup = new PaymentSourceLookup(

             code, name, description
             );

            return await _paymentSourceLookupRepository.InsertAsync(paymentSourceLookup);
        }

        public virtual async Task<PaymentSourceLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentSourceLookup = await _paymentSourceLookupRepository.GetAsync(id);

            paymentSourceLookup.Code = code;
            paymentSourceLookup.Name = name;
            paymentSourceLookup.Description = description;

            paymentSourceLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _paymentSourceLookupRepository.UpdateAsync(paymentSourceLookup);
        }

    }
}