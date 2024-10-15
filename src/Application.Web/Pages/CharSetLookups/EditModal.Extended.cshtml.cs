using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.CharSetLookups;

namespace Application.Web.Pages.CharSetLookups
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(ICharSetLookupsAppService charSetLookupsAppService)
            : base(charSetLookupsAppService)
        {
        }
    }
}