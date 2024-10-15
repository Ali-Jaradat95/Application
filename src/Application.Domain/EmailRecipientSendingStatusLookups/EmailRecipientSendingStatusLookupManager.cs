using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Application.EmailRecipientSendingStatusLookups
{
    public abstract class EmailRecipientSendingStatusLookupManagerBase : DomainService
    {
        protected IEmailRecipientSendingStatusLookupRepository _emailRecipientSendingStatusLookupRepository;

        public EmailRecipientSendingStatusLookupManagerBase(IEmailRecipientSendingStatusLookupRepository emailRecipientSendingStatusLookupRepository)
        {
            _emailRecipientSendingStatusLookupRepository = emailRecipientSendingStatusLookupRepository;
        }

        public virtual async Task<EmailRecipientSendingStatusLookup> CreateAsync(
        string code, string name, string? description = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var emailRecipientSendingStatusLookup = new EmailRecipientSendingStatusLookup(

             code, name, description
             );

            return await _emailRecipientSendingStatusLookupRepository.InsertAsync(emailRecipientSendingStatusLookup);
        }

        public virtual async Task<EmailRecipientSendingStatusLookup> UpdateAsync(
            int id,
            string code, string name, string? description = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var emailRecipientSendingStatusLookup = await _emailRecipientSendingStatusLookupRepository.GetAsync(id);

            emailRecipientSendingStatusLookup.Code = code;
            emailRecipientSendingStatusLookup.Name = name;
            emailRecipientSendingStatusLookup.Description = description;

            emailRecipientSendingStatusLookup.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _emailRecipientSendingStatusLookupRepository.UpdateAsync(emailRecipientSendingStatusLookup);
        }

    }
}