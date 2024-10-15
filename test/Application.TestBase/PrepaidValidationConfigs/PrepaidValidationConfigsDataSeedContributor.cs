using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.PrepaidValidationConfigs;

namespace Application.PrepaidValidationConfigs
{
    public class PrepaidValidationConfigsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPrepaidValidationConfigRepository _prepaidValidationConfigRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PrepaidValidationConfigsDataSeedContributor(IPrepaidValidationConfigRepository prepaidValidationConfigRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _prepaidValidationConfigRepository = prepaidValidationConfigRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _prepaidValidationConfigRepository.InsertAsync(new PrepaidValidationConfig
            (
                serviceType: "60ece39aa9f647f5a0b9bf2b88e4bc04cd7f666193",
                channelCode: "304c9062396b4cd0a4a",
                billingName: "71f30869fb884a84847807616d9b",
                aliasBillingName: "94ea88fbc4754635886102fccb99dfa73c5dd6b309a3437a915",
                isTesting: true,
                endpointUrl: "dc9732139f454105b4956916a91b06109045953d260244abb6f944a4bfcde6"
            ));

            await _prepaidValidationConfigRepository.InsertAsync(new PrepaidValidationConfig
            (
                serviceType: "ba6a7583a06e4aa78d253239534878ed237",
                channelCode: "86f3e9633a114735b4d8aaabb0bc3502ee7f171e3",
                billingName: "14000ed29451487e8b91d6e8ec8f28d9d6c2fb10c58c453c86981a11ffdaaf51d404e8fa89394179bdceefd13c934fdcf0",
                aliasBillingName: "251da3f133f641529412d3b38196330623",
                isTesting: true,
                endpointUrl: "ebfee3ed943e4fa4b330415912962494277f"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}