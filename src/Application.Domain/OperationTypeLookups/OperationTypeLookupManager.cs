using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.OperationTypeLookups
{
    public abstract class OperationTypeLookupManagerBase : DomainService
    {
        protected IOperationTypeLookupRepository _operationTypeLookupRepository;

        public OperationTypeLookupManagerBase(IOperationTypeLookupRepository operationTypeLookupRepository)
        {
            _operationTypeLookupRepository = operationTypeLookupRepository;
        }

        public virtual async Task<OperationTypeLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var operationTypeLookup = new OperationTypeLookup(

             code, name, description
             );

            return await _operationTypeLookupRepository.InsertAsync(operationTypeLookup);
        }

        public virtual async Task<OperationTypeLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var operationTypeLookup = await _operationTypeLookupRepository.GetAsync(id);

            operationTypeLookup.Code = code;
            operationTypeLookup.Name = name;
            operationTypeLookup.Description = description;

            operationTypeLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _operationTypeLookupRepository.UpdateAsync(operationTypeLookup);
        }

    }
}