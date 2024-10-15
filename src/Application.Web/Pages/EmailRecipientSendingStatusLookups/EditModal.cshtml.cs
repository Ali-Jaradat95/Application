using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.EmailRecipientSendingStatusLookups;

namespace Application.Web.Pages.EmailRecipientSendingStatusLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public EmailRecipientSendingStatusLookupUpdateViewModel EmailRecipientSendingStatusLookup { get; set; }

        protected IEmailRecipientSendingStatusLookupsAppService _emailRecipientSendingStatusLookupsAppService;

        public EditModalModelBase(IEmailRecipientSendingStatusLookupsAppService emailRecipientSendingStatusLookupsAppService)
        {
            _emailRecipientSendingStatusLookupsAppService = emailRecipientSendingStatusLookupsAppService;

            EmailRecipientSendingStatusLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var emailRecipientSendingStatusLookup = await _emailRecipientSendingStatusLookupsAppService.GetAsync(Id);
            EmailRecipientSendingStatusLookup = ObjectMapper.Map<EmailRecipientSendingStatusLookupDto, EmailRecipientSendingStatusLookupUpdateViewModel>(emailRecipientSendingStatusLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _emailRecipientSendingStatusLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<EmailRecipientSendingStatusLookupUpdateViewModel, EmailRecipientSendingStatusLookupUpdateDto>(EmailRecipientSendingStatusLookup));
            return NoContent();
        }
    }

    public class EmailRecipientSendingStatusLookupUpdateViewModel : EmailRecipientSendingStatusLookupUpdateDto
    {
    }
}