using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PaymentMethodLookups
{
    public abstract class PaymentMethodLookupManagerBase : DomainService
    {
        protected IPaymentMethodLookupRepository _paymentMethodLookupRepository;

        public PaymentMethodLookupManagerBase(IPaymentMethodLookupRepository paymentMethodLookupRepository)
        {
            _paymentMethodLookupRepository = paymentMethodLookupRepository;
        }

        public virtual async Task<PaymentMethodLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentMethodLookup = new PaymentMethodLookup(

             code, name, description
             );

            return await _paymentMethodLookupRepository.InsertAsync(paymentMethodLookup);
        }

        public virtual async Task<PaymentMethodLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentMethodLookup = await _paymentMethodLookupRepository.GetAsync(id);

            paymentMethodLookup.Code = code;
            paymentMethodLookup.Name = name;
            paymentMethodLookup.Description = description;

            paymentMethodLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _paymentMethodLookupRepository.UpdateAsync(paymentMethodLookup);
        }

    }
}