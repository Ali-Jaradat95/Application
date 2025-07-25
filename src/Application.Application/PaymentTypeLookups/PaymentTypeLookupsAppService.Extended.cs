using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Application.Permissions;
using Application.PaymentTypeLookups;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Application.Shared;

namespace Application.PaymentTypeLookups
{
    public class PaymentTypeLookupsAppService : PaymentTypeLookupsAppServiceBase, IPaymentTypeLookupsAppService
    {
        //<suite-custom-code-autogenerated>
        public PaymentTypeLookupsAppService(IPaymentTypeLookupRepository paymentTypeLookupRepository, PaymentTypeLookupManager paymentTypeLookupManager, IDistributedCache<PaymentTypeLookupExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
            : base(paymentTypeLookupRepository, paymentTypeLookupManager, excelDownloadTokenCache)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}