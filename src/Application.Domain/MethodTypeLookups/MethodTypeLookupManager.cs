using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.MethodTypeLookups
{
    public abstract class MethodTypeLookupManagerBase : DomainService
    {
        protected IMethodTypeLookupRepository _methodTypeLookupRepository;

        public MethodTypeLookupManagerBase(IMethodTypeLookupRepository methodTypeLookupRepository)
        {
            _methodTypeLookupRepository = methodTypeLookupRepository;
        }

        public virtual async Task<MethodTypeLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var methodTypeLookup = new MethodTypeLookup(

             code, name, description
             );

            return await _methodTypeLookupRepository.InsertAsync(methodTypeLookup);
        }

        public virtual async Task<MethodTypeLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var methodTypeLookup = await _methodTypeLookupRepository.GetAsync(id);

            methodTypeLookup.Code = code;
            methodTypeLookup.Name = name;
            methodTypeLookup.Description = description;

            methodTypeLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _methodTypeLookupRepository.UpdateAsync(methodTypeLookup);
        }

    }
}