using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.MessageEncodingLookups;

namespace Application.Web.Pages.MessageEncodingLookups
{
    public abstract class EditModalModelBase : ApplicationPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public MessageEncodingLookupUpdateViewModel MessageEncodingLookup { get; set; }

        protected IMessageEncodingLookupsAppService _messageEncodingLookupsAppService;

        public EditModalModelBase(IMessageEncodingLookupsAppService messageEncodingLookupsAppService)
        {
            _messageEncodingLookupsAppService = messageEncodingLookupsAppService;

            MessageEncodingLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            var messageEncodingLookup = await _messageEncodingLookupsAppService.GetAsync(Id);
            MessageEncodingLookup = ObjectMapper.Map<MessageEncodingLookupDto, MessageEncodingLookupUpdateViewModel>(messageEncodingLookup);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _messageEncodingLookupsAppService.UpdateAsync(Id, ObjectMapper.Map<MessageEncodingLookupUpdateViewModel, MessageEncodingLookupUpdateDto>(MessageEncodingLookup));
            return NoContent();
        }
    }

    public class MessageEncodingLookupUpdateViewModel : MessageEncodingLookupUpdateDto
    {
    }
}