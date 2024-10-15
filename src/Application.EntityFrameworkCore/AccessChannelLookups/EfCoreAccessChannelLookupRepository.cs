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
    public abstract class EfCoreAccessChannelLookupRepositoryBase : EfCoreRepository<ApplicationDbContext, AccessChannelLookup, int>, IAccessChannelLookupRepository
    {
        public EfCoreAccessChannelLookupRepositoryBase(IDbContextProvider<ApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<AccessChannelLookup>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? description = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AccessChannelLookupConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? description = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, name, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AccessChannelLookup> ApplyFilter(
            IQueryable<AccessChannelLookup> query,
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code!.Contains(filterText!) || e.Name!.Contains(filterText!) || e.Description!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description));
        }
    }
}