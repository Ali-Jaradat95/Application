using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.AccessChannelLookups;

namespace Application.AccessChannelLookups
{
    public class AccessChannelLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IAccessChannelLookupRepository _accessChannelLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AccessChannelLookupsDataSeedContributor(IAccessChannelLookupRepository accessChannelLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _accessChannelLookupRepository = accessChannelLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _accessChannelLookupRepository.InsertAsync(new AccessChannelLookup
            (
                code: "887b69f51",
                name: "d2966ccbe1f24e638",
                description: "2f718aaee9184dbeb4c9f4eab6caaf3ec142850335a0460da57e221d9d5a628894e0e1e53572486180f312e"
            ));

            await _accessChannelLookupRepository.InsertAsync(new AccessChannelLookup
            (
                code: "c2a27fa4a4864cecbb0499732933485e35b3573734c34b62a51c",
                name: "5df8437a15d74b18a01048557f65f2cf7c4a33f8ac97416bbc48e54bc3a4ed4ed7e4c337d3",
                description: "157070a4dca4457ca52212c3c1879928d7497527ae434e20b3ecff4f414eb3c647e5ed65ed"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}