using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.EmailRecipientSendingStatusLookups;

namespace Application.Web.Pages.EmailRecipientSendingStatusLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public EmailRecipientSendingStatusLookupCreateViewModel EmailRecipientSendingStatusLookup { get; set; }

        protected IEmailRecipientSendingStatusLookupsAppService _emailRecipientSendingStatusLookupsAppService;

        public CreateModalModelBase(IEmailRecipientSendingStatusLookupsAppService emailRecipientSendingStatusLookupsAppService)
        {
            _emailRecipientSendingStatusLookupsAppService = emailRecipientSendingStatusLookupsAppService;

            EmailRecipientSendingStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            EmailRecipientSendingStatusLookup = new EmailRecipientSendingStatusLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _emailRecipientSendingStatusLookupsAppService.CreateAsync(ObjectMapper.Map<EmailRecipientSendingStatusLookupCreateViewModel, EmailRecipientSendingStatusLookupCreateDto>(EmailRecipientSendingStatusLookup));
            return NoContent();
        }
    }

    public class EmailRecipientSendingStatusLookupCreateViewModel : EmailRecipientSendingStatusLookupCreateDto
    {
    }
}