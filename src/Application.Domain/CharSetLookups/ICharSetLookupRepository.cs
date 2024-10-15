using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.CharSetLookups
{
    public partial interface ICharSetLookupRepository : IRepository<CharSetLookup, int>
    {
        Task<List<CharSetLookup>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? description = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? description = null,
            CancellationToken cancellationToken = default);
    }
}