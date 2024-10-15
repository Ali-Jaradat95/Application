using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.CharSetLookups
{
    public abstract class CharSetLookupManagerBase : DomainService
    {
        protected ICharSetLookupRepository _charSetLookupRepository;

        public CharSetLookupManagerBase(ICharSetLookupRepository charSetLookupRepository)
        {
            _charSetLookupRepository = charSetLookupRepository;
        }

        public virtual async Task<CharSetLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var charSetLookup = new CharSetLookup(

             code, name, description
             );

            return await _charSetLookupRepository.InsertAsync(charSetLookup);
        }

        public virtual async Task<CharSetLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var charSetLookup = await _charSetLookupRepository.GetAsync(id);

            charSetLookup.Code = code;
            charSetLookup.Name = name;
            charSetLookup.Description = description;

            charSetLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _charSetLookupRepository.UpdateAsync(charSetLookup);
        }

    }
}