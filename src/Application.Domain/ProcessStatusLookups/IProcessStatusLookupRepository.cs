using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Application.ProcessStatusLookups
{
    public partial interface IProcessStatusLookupRepository : IRepository<ProcessStatusLookup, int>
    {
        Task<List<ProcessStatusLookup>> GetListAsync(
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