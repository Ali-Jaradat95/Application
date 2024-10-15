using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.BillingStatusLookups;

namespace Application.BillingStatusLookups
{
    public class BillingStatusLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IBillingStatusLookupRepository _billingStatusLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public BillingStatusLookupsDataSeedContributor(IBillingStatusLookupRepository billingStatusLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _billingStatusLookupRepository = billingStatusLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _billingStatusLookupRepository.InsertAsync(new BillingStatusLookup
            (
                code: "bcbca878259848cc9337818303f891572b440c0ab7044d3bb8900ee42cd8affaa1f8f7f1ac664",
                name: "db1a13eb7cb8",
                description: "54ac097557b1401abfe25debc7b45dc8915111d60aec476cb5996ee73f2366b139ad6a4ed"
            ));

            await _billingStatusLookupRepository.InsertAsync(new BillingStatusLookup
            (
                code: "5e23b2cc6670400f93c3ca55d667831e691645a70b0b4cd4a403d3a7f9d1af144dfd744f5a0749",
                name: "d2cb1b17131445c6a56f166d3f04ff31a6b8369f84a744078a",
                description: "a6c6cfc2a29c4ed0819aedb78f91289f1aea"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}