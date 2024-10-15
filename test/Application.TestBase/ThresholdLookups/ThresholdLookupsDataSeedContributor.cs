using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.ThresholdLookups;

namespace Application.ThresholdLookups
{
    public class ThresholdLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IThresholdLookupRepository _thresholdLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ThresholdLookupsDataSeedContributor(IThresholdLookupRepository thresholdLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _thresholdLookupRepository = thresholdLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _thresholdLookupRepository.InsertAsync(new ThresholdLookup
            (
                code: "dc44b242400d4ce289d25f271fe6c90b0f18c792b96141e19cb97bf8a388d80828fd5389b514486597c668412",
                name: "f0826a38b7ae41e2b23164ee6b9f3",
                description: "fb91c2dd88c14e0b855fa44168d0ed38dab8f7536da0485f8a1866b949a25033b827127a27dc4"
            ));

            await _thresholdLookupRepository.InsertAsync(new ThresholdLookup
            (
                code: "b704c73da6f0467692255b7954cb9f9303cce94705974c84a33b6909f47c7dd5a12d14aa96bd43f383721e8c5f93b",
                name: "ffb3f1081c5e4de4be1f95f218bd096bd850a5328bd9426281aee5e73f64ef98c9f0366a4b384e7193dc4c1",
                description: "872fbb4e6d4c49d595c253a3053844c9"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}