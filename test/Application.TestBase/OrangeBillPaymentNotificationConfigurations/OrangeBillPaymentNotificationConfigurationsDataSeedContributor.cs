using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.OrangeBillPaymentNotificationConfigurations;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public class OrangeBillPaymentNotificationConfigurationsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IOrangeBillPaymentNotificationConfigurationRepository _orangeBillPaymentNotificationConfigurationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OrangeBillPaymentNotificationConfigurationsDataSeedContributor(IOrangeBillPaymentNotificationConfigurationRepository orangeBillPaymentNotificationConfigurationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _orangeBillPaymentNotificationConfigurationRepository = orangeBillPaymentNotificationConfigurationRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _orangeBillPaymentNotificationConfigurationRepository.InsertAsync(new OrangeBillPaymentNotificationConfiguration
            (
                serviceTypeName: "9d3aba65e58946059677e92d7d543de92e6c95989d8748cc8",
                configurationKey: "8b8066c6f706417aa8ae39b04f416dd16486c7de7f4844648c4dd0d8321",
                configurationValue: "e980c757642d41a8b61ab8c0713e9374c3"
            ));

            await _orangeBillPaymentNotificationConfigurationRepository.InsertAsync(new OrangeBillPaymentNotificationConfiguration
            (
                serviceTypeName: "fdf56efbe9ab40018f2a80a",
                configurationKey: "dd9d58127ea941e1b90",
                configurationValue: "6965deb"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}