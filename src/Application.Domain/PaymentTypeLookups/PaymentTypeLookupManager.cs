using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PaymentTypeLookups
{
    public abstract class PaymentTypeLookupManagerBase : DomainService
    {
        protected IPaymentTypeLookupRepository _paymentTypeLookupRepository;

        public PaymentTypeLookupManagerBase(IPaymentTypeLookupRepository paymentTypeLookupRepository)
        {
            _paymentTypeLookupRepository = paymentTypeLookupRepository;
        }

        public virtual async Task<PaymentTypeLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentTypeLookup = new PaymentTypeLookup(

             code, name, description
             );

            return await _paymentTypeLookupRepository.InsertAsync(paymentTypeLookup);
        }

        public virtual async Task<PaymentTypeLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var paymentTypeLookup = await _paymentTypeLookupRepository.GetAsync(id);

            paymentTypeLookup.Code = code;
            paymentTypeLookup.Name = name;
            paymentTypeLookup.Description = description;

            paymentTypeLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _paymentTypeLookupRepository.UpdateAsync(paymentTypeLookup);
        }

    }
}