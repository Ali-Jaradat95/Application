using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.MethodTypeLookups;

namespace Application.MethodTypeLookups
{
    public class MethodTypeLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMethodTypeLookupRepository _methodTypeLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MethodTypeLookupsDataSeedContributor(IMethodTypeLookupRepository methodTypeLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _methodTypeLookupRepository = methodTypeLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _methodTypeLookupRepository.InsertAsync(new MethodTypeLookup
            (
                code: "98553aa4c1984008ab1f22d3e0e8208ae15ed02ee71e47a5a21704ed5bae25ed1c01d54979e64b88",
                name: "ebfa4e6983f24d0197406699ab82e36daa399b123e2b4e9187d99837e",
                description: "5ed55e37120a4258a787f37a67309ad0b66e165835734804b7160485d36e086055cb8b61a37c41868b1d"
            ));

            await _methodTypeLookupRepository.InsertAsync(new MethodTypeLookup
            (
                code: "b0fad612907645aea24f0dadd30fa47075aab5c7ce214294a19a2d09fd550a1a517fd30688524e3b9b6f5",
                name: "cb742cb3fd7f4c53b8d4054595da059af102ef7648cf4f199f880ae8aa7cd07f6bbf00",
                description: "dc0aea9e55974902ae71fface9c9aedc7921a815e7f44da6a694710e34fda539e34b6cd5d7004"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}