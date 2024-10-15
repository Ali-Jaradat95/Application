using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.BillingStatusLookups
{
    public abstract class BillingStatusLookupManagerBase : DomainService
    {
        protected IBillingStatusLookupRepository _billingStatusLookupRepository;

        public BillingStatusLookupManagerBase(IBillingStatusLookupRepository billingStatusLookupRepository)
        {
            _billingStatusLookupRepository = billingStatusLookupRepository;
        }

        public virtual async Task<BillingStatusLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billingStatusLookup = new BillingStatusLookup(

             code, name, description
             );

            return await _billingStatusLookupRepository.InsertAsync(billingStatusLookup);
        }

        public virtual async Task<BillingStatusLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billingStatusLookup = await _billingStatusLookupRepository.GetAsync(id);

            billingStatusLookup.Code = code;
            billingStatusLookup.Name = name;
            billingStatusLookup.Description = description;

            billingStatusLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _billingStatusLookupRepository.UpdateAsync(billingStatusLookup);
        }

    }
}