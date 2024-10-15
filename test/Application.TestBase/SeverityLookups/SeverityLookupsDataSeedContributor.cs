using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.SeverityLookups;

namespace Application.SeverityLookups
{
    public class SeverityLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISeverityLookupRepository _severityLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SeverityLookupsDataSeedContributor(ISeverityLookupRepository severityLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _severityLookupRepository = severityLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _severityLookupRepository.InsertAsync(new SeverityLookup
            (
                code: "56a2509cd6284ef1bba457cb2090092e3090a136d6404744aaeaee5992e2cbfa4b833182773c44c7ac7f97a",
                name: "1dd0bd7644ef40ea8c095a1532d3802a2dd1c0ee21a54bb9991fa2138a0b4",
                description: "7a8a112f62ba400a8c970f664e998e0881def45d43e64838a96b185031d4acfe57f"
            ));

            await _severityLookupRepository.InsertAsync(new SeverityLookup
            (
                code: "627a52244f92417bbc754bd520b2d53f0808907b",
                name: "3ecebadbf79b46029f9ca2060681b95e6c2d1f9ed59f45ddb3f1",
                description: "fd87aa5bfb3146f3a3c026494c6"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}