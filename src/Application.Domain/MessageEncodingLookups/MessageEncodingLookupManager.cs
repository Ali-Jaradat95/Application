using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.MessageEncodingLookups
{
    public abstract class MessageEncodingLookupManagerBase : DomainService
    {
        protected IMessageEncodingLookupRepository _messageEncodingLookupRepository;

        public MessageEncodingLookupManagerBase(IMessageEncodingLookupRepository messageEncodingLookupRepository)
        {
            _messageEncodingLookupRepository = messageEncodingLookupRepository;
        }

        public virtual async Task<MessageEncodingLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var messageEncodingLookup = new MessageEncodingLookup(

             code, name, description
             );

            return await _messageEncodingLookupRepository.InsertAsync(messageEncodingLookup);
        }

        public virtual async Task<MessageEncodingLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var messageEncodingLookup = await _messageEncodingLookupRepository.GetAsync(id);

            messageEncodingLookup.Code = code;
            messageEncodingLookup.Name = name;
            messageEncodingLookup.Description = description;

            messageEncodingLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _messageEncodingLookupRepository.UpdateAsync(messageEncodingLookup);
        }

    }
}