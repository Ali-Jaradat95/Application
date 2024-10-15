using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.BillStatusLookups;

namespace Application.BillStatusLookups
{
    public class BillStatusLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IBillStatusLookupRepository _billStatusLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public BillStatusLookupsDataSeedContributor(IBillStatusLookupRepository billStatusLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _billStatusLookupRepository = billStatusLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _billStatusLookupRepository.InsertAsync(new BillStatusLookup
            (
                code: "ebf0c5cc73a14f0f8ff9fb82",
                name: "6562958794c64ea69a8e3f450edfc611d2bc0ab70ee94290b0425a613784b78763ab46e0a9db",
                description: "4632a734bd974962bf890da28e0b33ffecec5a3705c14d8594ba3e7eb6c553b89cc3bc953dd84d77810913cacc25dffd"
            ));

            await _billStatusLookupRepository.InsertAsync(new BillStatusLookup
            (
                code: "a8fc55f2c9ca4be298ffd1ecdeec589c5beec051b3b9426cafbc9084",
                name: "1149ff3265ee42a286d709852ef63138922b0442b7464732a56e9e8",
                description: "090b51e0596"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}