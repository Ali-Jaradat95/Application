using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.BillTypeLookups;

namespace Application.BillTypeLookups
{
    public class BillTypeLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IBillTypeLookupRepository _billTypeLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public BillTypeLookupsDataSeedContributor(IBillTypeLookupRepository billTypeLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _billTypeLookupRepository = billTypeLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _billTypeLookupRepository.InsertAsync(new BillTypeLookup
            (
                code: "5e7346e22b7846",
                name: "0141d10b736645c599ba6b0745d617b87f61cc1ffbc",
                description: "800e15a9f51e4d"
            ));

            await _billTypeLookupRepository.InsertAsync(new BillTypeLookup
            (
                code: "a4968b7af99749d39c1364d8ec596ce127eed2afd0f54702b4f3e95d2394b525730b3082a65f4cd18ce3c",
                name: "4f914741e92c4d6fabeeeacaecd892700",
                description: "4e77a370053c4a11939b3"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}