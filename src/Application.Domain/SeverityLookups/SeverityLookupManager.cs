using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.SeverityLookups
{
    public abstract class SeverityLookupManagerBase : DomainService
    {
        protected ISeverityLookupRepository _severityLookupRepository;

        public SeverityLookupManagerBase(ISeverityLookupRepository severityLookupRepository)
        {
            _severityLookupRepository = severityLookupRepository;
        }

        public virtual async Task<SeverityLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var severityLookup = new SeverityLookup(

             code, name, description
             );

            return await _severityLookupRepository.InsertAsync(severityLookup);
        }

        public virtual async Task<SeverityLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var severityLookup = await _severityLookupRepository.GetAsync(id);

            severityLookup.Code = code;
            severityLookup.Name = name;
            severityLookup.Description = description;

            severityLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _severityLookupRepository.UpdateAsync(severityLookup);
        }

    }
}