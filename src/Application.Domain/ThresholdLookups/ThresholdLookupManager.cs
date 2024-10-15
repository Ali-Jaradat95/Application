using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.ThresholdLookups
{
    public abstract class ThresholdLookupManagerBase : DomainService
    {
        protected IThresholdLookupRepository _thresholdLookupRepository;

        public ThresholdLookupManagerBase(IThresholdLookupRepository thresholdLookupRepository)
        {
            _thresholdLookupRepository = thresholdLookupRepository;
        }

        public virtual async Task<ThresholdLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var thresholdLookup = new ThresholdLookup(

             code, name, description
             );

            return await _thresholdLookupRepository.InsertAsync(thresholdLookup);
        }

        public virtual async Task<ThresholdLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var thresholdLookup = await _thresholdLookupRepository.GetAsync(id);

            thresholdLookup.Code = code;
            thresholdLookup.Name = name;
            thresholdLookup.Description = description;

            thresholdLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _thresholdLookupRepository.UpdateAsync(thresholdLookup);
        }

    }
}