using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.BillStatusLookups
{
    public abstract class BillStatusLookupManagerBase : DomainService
    {
        protected IBillStatusLookupRepository _billStatusLookupRepository;

        public BillStatusLookupManagerBase(IBillStatusLookupRepository billStatusLookupRepository)
        {
            _billStatusLookupRepository = billStatusLookupRepository;
        }

        public virtual async Task<BillStatusLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billStatusLookup = new BillStatusLookup(

             code, name, description
             );

            return await _billStatusLookupRepository.InsertAsync(billStatusLookup);
        }

        public virtual async Task<BillStatusLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var billStatusLookup = await _billStatusLookupRepository.GetAsync(id);

            billStatusLookup.Code = code;
            billStatusLookup.Name = name;
            billStatusLookup.Description = description;

            billStatusLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _billStatusLookupRepository.UpdateAsync(billStatusLookup);
        }

    }
}