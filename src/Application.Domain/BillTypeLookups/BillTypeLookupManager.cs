using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.BillTypeLookups
{
    public abstract class BillTypeLookupManagerBase : DomainService
    {
        protected IBillTypeLookupRepository _billTypeLookupRepository;

        public BillTypeLookupManagerBase(IBillTypeLookupRepository billTypeLookupRepository)
        {
            _billTypeLookupRepository = billTypeLookupRepository;
        }

        public virtual async Task<BillTypeLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billTypeLookup = new BillTypeLookup(

             code, name, description
             );

            return await _billTypeLookupRepository.InsertAsync(billTypeLookup);
        }

        public virtual async Task<BillTypeLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billTypeLookup = await _billTypeLookupRepository.GetAsync(id);

            billTypeLookup.Code = code;
            billTypeLookup.Name = name;
            billTypeLookup.Description = description;

            billTypeLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _billTypeLookupRepository.UpdateAsync(billTypeLookup);
        }

    }
}