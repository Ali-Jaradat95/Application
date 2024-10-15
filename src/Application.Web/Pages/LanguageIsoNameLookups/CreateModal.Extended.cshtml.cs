using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.LanguageIsoNameLookups;

namespace Application.Web.Pages.LanguageIsoNameLookups
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(ILanguageIsoNameLookupsAppService languageIsoNameLookupsAppService)
            : base(languageIsoNameLookupsAppService)
        {
        }
    }
}