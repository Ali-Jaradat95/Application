using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.MessageEncodingLookups;

namespace Application.Web.Pages.MessageEncodingLookups
{
    public abstract class CreateModalModelBase : ApplicationPageModel
    {
        [BindProperty]
        public MessageEncodingLookupCreateViewModel MessageEncodingLookup { get; set; }

        protected IMessageEncodingLookupsAppService _messageEncodingLookupsAppService;

        public CreateModalModelBase(IMessageEncodingLookupsAppService messageEncodingLookupsAppService)
        {
            _messageEncodingLookupsAppService = messageEncodingLookupsAppService;

            MessageEncodingLookup = new();
        }

        public virtual async Task OnGetAsync()
        {
            MessageEncodingLookup = new MessageEncodingLookupCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _messageEncodingLookupsAppService.CreateAsync(ObjectMapper.Map<MessageEncodingLookupCreateViewModel, MessageEncodingLookupCreateDto>(MessageEncodingLookup));
            return NoContent();
        }
    }

    public class MessageEncodingLookupCreateViewModel : MessageEncodingLookupCreateDto
    {
    }
}