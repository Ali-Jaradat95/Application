using Application.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ServiceTypeLookups;

namespace Application.Web.Pages.ServiceTypeLookups
{
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IServiceTypeLookupsAppService serviceTypeLookupsAppService)
            : base(serviceTypeLookupsAppService)
        {
        }
    }
}