using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.ServiceTypeLookups
{
    public abstract class ServiceTypeLookupManagerBase : DomainService
    {
        protected IServiceTypeLookupRepository _serviceTypeLookupRepository;

        public ServiceTypeLookupManagerBase(IServiceTypeLookupRepository serviceTypeLookupRepository)
        {
            _serviceTypeLookupRepository = serviceTypeLookupRepository;
        }

        public virtual async Task<ServiceTypeLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var serviceTypeLookup = new ServiceTypeLookup(

             code, name, description
             );

            return await _serviceTypeLookupRepository.InsertAsync(serviceTypeLookup);
        }

        public virtual async Task<ServiceTypeLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var serviceTypeLookup = await _serviceTypeLookupRepository.GetAsync(id);

            serviceTypeLookup.Code = code;
            serviceTypeLookup.Name = name;
            serviceTypeLookup.Description = description;

            serviceTypeLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _serviceTypeLookupRepository.UpdateAsync(serviceTypeLookup);
        }

    }
}