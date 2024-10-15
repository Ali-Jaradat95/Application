using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.OrangeBillPullServiceConfigurations;

namespace Application.OrangeBillPullServiceConfigurations
{
    public class OrangeBillPullServiceConfigurationsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IOrangeBillPullServiceConfigurationRepository _orangeBillPullServiceConfigurationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OrangeBillPullServiceConfigurationsDataSeedContributor(IOrangeBillPullServiceConfigurationRepository orangeBillPullServiceConfigurationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _orangeBillPullServiceConfigurationRepository = orangeBillPullServiceConfigurationRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _orangeBillPullServiceConfigurationRepository.InsertAsync(new OrangeBillPullServiceConfiguration
            (
                serviceTypeId: 1022337222,
                isServiceEnabled: true,
                isWebServiceEnabled: true,
                webServiceUrl: "b45e486590b04a00b345d8a44a9b501ee2bcf60e264544bd8e53af9ba9973e7bc01c69f5de",
                storedProcedureName: "3899a811deac4f24a1d1e1a463cee58605ec6",
                billerCode: "c362d65b039349b79926e2feb4be6674659cb26a39df4dc58fcd49ea6497cd6d1f3a971cbd69481aa7b83a17",
                connectionStringUserId: "a92bf78b9fcf4e9795f497c316cde32426610736e4624fcb9ca92e800f",
                connectionStringPassword: "1862f3df781c418eb",
                connectionStringDataSource: "d7f30b1ea3ed49",
                logLevel: "2941e608ed1b4ccf82869f43c0703a54e3cb0cae735341cc81042e8fa0569037da85ca9b1f3d4cf7923af",
                severityId: 1886385641,
                dailyLimit: 1330212290,
                weeklyLimit: 289934079,
                monthlyLimit: 1172928964,
                yearlyLimit: 817164515,
                errorMessage: "d6a2e20699f34a8593a4174b9981b85683cd6aa5dd2c4359b3e9dbd5ae36930bfa31e5a89ecd47f9b25bcb2"
            ));

            await _orangeBillPullServiceConfigurationRepository.InsertAsync(new OrangeBillPullServiceConfiguration
            (
                serviceTypeId: 2140737403,
                isServiceEnabled: true,
                isWebServiceEnabled: true,
                webServiceUrl: "ee55124c683d431491c32ad4d42c64057b868eac7a4145f1bde4727cb7961708db875cb7cfd44391bad3d",
                storedProcedureName: "4ecd5088602848708c5fdd63286026c9a9b2a59677f04f15b9781054e173abde9962b79adb72468087eee9e59664e",
                billerCode: "bb88626c252948a1b498b7642b20c63f83bd09ef598c4",
                connectionStringUserId: "7c7c893d90374f138c9cecbd7f411f7db9901b4aa0a646e7878ea483352",
                connectionStringPassword: "e6f8309b31354db9839a135d6164eafce5f8427d8d9a4738b1ba9776b7df7a4de434fc8515634eecbfbbf8f8221f",
                connectionStringDataSource: "a1da21a46a794c6eaca50e7ab56a7ed1c8a5232b9a224fc8baa5de4c9de6891dcda410c963d84150b4876fbde0ebffc458d",
                logLevel: "7257b0d623e64d30b9d6b987e49598db7",
                severityId: 1983045715,
                dailyLimit: 807220090,
                weeklyLimit: 676621404,
                monthlyLimit: 1959598918,
                yearlyLimit: 129552220,
                errorMessage: "22d7650297c34"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}