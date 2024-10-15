using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.CharSetLookups;

namespace Application.CharSetLookups
{
    public class CharSetLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICharSetLookupRepository _charSetLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CharSetLookupsDataSeedContributor(ICharSetLookupRepository charSetLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _charSetLookupRepository = charSetLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _charSetLookupRepository.InsertAsync(new CharSetLookup
            (
                code: "cd48d01492374e9893280ae111db5d79a0654451a2634827b65720296f2e5efa",
                name: "753afacffed143ee98a9bb3c3ea2eb041c8caee",
                description: "48d64832979a4e8f99027d25477217e"
            ));

            await _charSetLookupRepository.InsertAsync(new CharSetLookup
            (
                code: "460e21d981d74da6a724bbe8b0b4e11d6e356dbdec274c0491384dacecbd26eb3c467db25621485e8",
                name: "7bd6a4dc509b46d7ac0ac94ade05144d1d",
                description: "5cebe6fdd6be4b3f9"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}