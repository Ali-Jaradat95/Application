using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.PrepaidCategoryLookups
{
    public abstract class PrepaidCategoryLookupManagerBase : DomainService
    {
        protected IPrepaidCategoryLookupRepository _prepaidCategoryLookupRepository;

        public PrepaidCategoryLookupManagerBase(IPrepaidCategoryLookupRepository prepaidCategoryLookupRepository)
        {
            _prepaidCategoryLookupRepository = prepaidCategoryLookupRepository;
        }

        public virtual async Task<PrepaidCategoryLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var prepaidCategoryLookup = new PrepaidCategoryLookup(

             code, name, description
             );

            return await _prepaidCategoryLookupRepository.InsertAsync(prepaidCategoryLookup);
        }

        public virtual async Task<PrepaidCategoryLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var prepaidCategoryLookup = await _prepaidCategoryLookupRepository.GetAsync(id);

            prepaidCategoryLookup.Code = code;
            prepaidCategoryLookup.Name = name;
            prepaidCategoryLookup.Description = description;

            prepaidCategoryLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _prepaidCategoryLookupRepository.UpdateAsync(prepaidCategoryLookup);
        }

    }
}