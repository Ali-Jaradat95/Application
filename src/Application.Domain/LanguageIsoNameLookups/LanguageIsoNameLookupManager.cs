using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.LanguageIsoNameLookups
{
    public abstract class LanguageIsoNameLookupManagerBase : DomainService
    {
        protected ILanguageIsoNameLookupRepository _languageIsoNameLookupRepository;

        public LanguageIsoNameLookupManagerBase(ILanguageIsoNameLookupRepository languageIsoNameLookupRepository)
        {
            _languageIsoNameLookupRepository = languageIsoNameLookupRepository;
        }

        public virtual async Task<LanguageIsoNameLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var languageIsoNameLookup = new LanguageIsoNameLookup(

             code, name, description
             );

            return await _languageIsoNameLookupRepository.InsertAsync(languageIsoNameLookup);
        }

        public virtual async Task<LanguageIsoNameLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var languageIsoNameLookup = await _languageIsoNameLookupRepository.GetAsync(id);

            languageIsoNameLookup.Code = code;
            languageIsoNameLookup.Name = name;
            languageIsoNameLookup.Description = description;

            languageIsoNameLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _languageIsoNameLookupRepository.UpdateAsync(languageIsoNameLookup);
        }

    }
}