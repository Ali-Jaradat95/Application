using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Application.EntityFrameworkCore;

namespace Application.PaymentCurrencyLookups
{
    public class EfCorePaymentCurrencyLookupRepository : EfCorePaymentCurrencyLookupRepositoryBase
    {
        public EfCorePaymentCurrencyLookupRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}