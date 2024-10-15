using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.AccessChannelLookups
{
    public abstract class AccessChannelLookupManagerBase : DomainService
    {
        protected IAccessChannelLookupRepository _accessChannelLookupRepository;

        public AccessChannelLookupManagerBase(IAccessChannelLookupRepository accessChannelLookupRepository)
        {
            _accessChannelLookupRepository = accessChannelLookupRepository;
        }

        public virtual async Task<AccessChannelLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var accessChannelLookup = new AccessChannelLookup(

             code, name, description
             );

            return await _accessChannelLookupRepository.InsertAsync(accessChannelLookup);
        }

        public virtual async Task<AccessChannelLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var accessChannelLookup = await _accessChannelLookupRepository.GetAsync(id);

            accessChannelLookup.Code = code;
            accessChannelLookup.Name = name;
            accessChannelLookup.Description = description;

            accessChannelLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _accessChannelLookupRepository.UpdateAsync(accessChannelLookup);
        }

    }
}