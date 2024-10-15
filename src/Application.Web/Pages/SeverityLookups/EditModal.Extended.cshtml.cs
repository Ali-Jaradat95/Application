using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.SeverityLookups;

namespace Application.Web.Pages.SeverityLookups
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(ISeverityLookupsAppService severityLookupsAppService)
            : base(severityLookupsAppService)
        {
        }
    }
}