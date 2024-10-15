using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PaymentCurrencyLookups
{
    public abstract class PaymentCurrencyLookupManagerBase : DomainService
    {
        protected IPaymentCurrencyLookupRepository _paymentCurrencyLookupRepository;

        public PaymentCurrencyLookupManagerBase(IPaymentCurrencyLookupRepository paymentCurrencyLookupRepository)
        {
            _paymentCurrencyLookupRepository = paymentCurrencyLookupRepository;
        }

        public virtual async Task<PaymentCurrencyLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentCurrencyLookup = new PaymentCurrencyLookup(

             code, name, description
             );

            return await _paymentCurrencyLookupRepository.InsertAsync(paymentCurrencyLookup);
        }

        public virtual async Task<PaymentCurrencyLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentCurrencyLookup = await _paymentCurrencyLookupRepository.GetAsync(id);

            paymentCurrencyLookup.Code = code;
            paymentCurrencyLookup.Name = name;
            paymentCurrencyLookup.Description = description;

            paymentCurrencyLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _paymentCurrencyLookupRepository.UpdateAsync(paymentCurrencyLookup);
        }

    }
}