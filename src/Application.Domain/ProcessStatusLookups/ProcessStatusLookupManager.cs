using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.ProcessStatusLookups
{
    public abstract class ProcessStatusLookupManagerBase : DomainService
    {
        protected IProcessStatusLookupRepository _processStatusLookupRepository;

        public ProcessStatusLookupManagerBase(IProcessStatusLookupRepository processStatusLookupRepository)
        {
            _processStatusLookupRepository = processStatusLookupRepository;
        }

        public virtual async Task<ProcessStatusLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var processStatusLookup = new ProcessStatusLookup(

             code, name, description
             );

            return await _processStatusLookupRepository.InsertAsync(processStatusLookup);
        }

        public virtual async Task<ProcessStatusLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var processStatusLookup = await _processStatusLookupRepository.GetAsync(id);

            processStatusLookup.Code = code;
            processStatusLookup.Name = name;
            processStatusLookup.Description = description;

            processStatusLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _processStatusLookupRepository.UpdateAsync(processStatusLookup);
        }

    }
}