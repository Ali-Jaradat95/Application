using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.AccessChannelLookups;

namespace Application.Web.Pages.AccessChannelLookups
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IAccessChannelLookupsAppService accessChannelLookupsAppService)
            : base(accessChannelLookupsAppService)
        {
        }
    }
}