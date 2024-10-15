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

namespace Application.AccessChannelLookups
{
    public class EfCoreAccessChannelLookupRepository : EfCoreAccessChannelLookupRepositoryBase
    {
        public EfCoreAccessChannelLookupRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}