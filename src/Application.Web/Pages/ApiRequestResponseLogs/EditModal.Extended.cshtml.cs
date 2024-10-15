using Application.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Application.ApiRequestResponseLogs;

namespace Application.Web.Pages.ApiRequestResponseLogs
{
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IApiRequestResponseLogsAppService apiRequestResponseLogsAppService)
            : base(apiRequestResponseLogsAppService)
        {
        }
    }
}