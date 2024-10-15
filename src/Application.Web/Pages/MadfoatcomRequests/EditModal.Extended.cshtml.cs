using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.MadfoatcomRequests;

namespace Application.Web.Pages.MadfoatcomRequests
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IMadfoatcomRequestsAppService madfoatcomRequestsAppService)
            : base(madfoatcomRequestsAppService)
        {
        }
    }
}