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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IEmailRecipientSendingStatusLookupsAppService emailRecipientSendingStatusLookupsAppService)
            : base(emailRecipientSendingStatusLookupsAppService)
        {
        }
    }
}