using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.OrangeBillPullServiceConfigurations
{
    public class OrangeBillPullServiceConfigurationsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IOrangeBillPullServiceConfigurationsAppService _orangeBillPullServiceConfigurationsAppService;
        private readonly IRepository<OrangeBillPullServiceConfiguration, int> _orangeBillPullServiceConfigurationRepository;

        public OrangeBillPullServiceConfigurationsAppServiceTests()
        {
            _orangeBillPullServiceConfigurationsAppService = GetRequiredService<IOrangeBillPullServiceConfigurationsAppService>();
            _orangeBillPullServiceConfigurationRepository = GetRequiredService<IRepository<OrangeBillPullServiceConfiguration, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _orangeBillPullServiceConfigurationsAppService.GetListAsync(new GetOrangeBillPullServiceConfigurationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _orangeBillPullServiceConfigurationsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new OrangeBillPullServiceConfigurationCreateDto
            {
                ServiceTypeId = 1129060588,
                IsServiceEnabled = true,
                IsWebServiceEnabled = true,
                WebServiceUrl = "4f5b15987af9481c9f0bac85de9981ab170336fec2c4487cafbe69b86e1fb9dafbba2e8cc3e8439e918bf22b829005eac0",
                StoredProcedureName = "a145acfc1147401082af247c8858",
                BillerCode = "d88538352fbf4f768b00b227c03fd786e3e3c2790",
                ConnectionStringUserId = "05bb75f070704371ae568bd2ab39647eab75d1af9dff4bf2bcbce9d8f1c5bb7e44cd2831ed5142d2a04bdd0",
                ConnectionStringPassword = "34b49975be934e02b94fe8c21c68253c36bb76398ca44f02b5666d68b310b384fe9163e2c140",
                ConnectionStringDataSource = "5bd0d627e5c347ab8b4f648c512",
                LogLevel = "c0eeb88176994e2f815bec6ea63b1bd0b9c727f6c82d4f83ad7b4f74d38c2bde46f9afda0f484028bcceee90c8996",
                SeverityId = 845674415,
                DailyLimit = 376710275,
                WeeklyLimit = 425717149,
                MonthlyLimit = 817784595,
                YearlyLimit = 197193679,
                ErrorMessage = "a55da323b97a480ab92e5e5281af6edb8de7ca33d21f4fbdaa747fe6689541ef8827d046fc0544d389fd48e"
            };

            // Act
            var serviceResult = await _orangeBillPullServiceConfigurationsAppService.CreateAsync(input);

            // Assert
            var result = await _orangeBillPullServiceConfigurationRepository.FindAsync(c => c.ServiceTypeId == serviceResult.ServiceTypeId);

            result.ShouldNotBe(null);
            result.ServiceTypeId.ShouldBe(1129060588);
            result.IsServiceEnabled.ShouldBe(true);
            result.IsWebServiceEnabled.ShouldBe(true);
            result.WebServiceUrl.ShouldBe("4f5b15987af9481c9f0bac85de9981ab170336fec2c4487cafbe69b86e1fb9dafbba2e8cc3e8439e918bf22b829005eac0");
            result.StoredProcedureName.ShouldBe("a145acfc1147401082af247c8858");
            result.BillerCode.ShouldBe("d88538352fbf4f768b00b227c03fd786e3e3c2790");
            result.ConnectionStringUserId.ShouldBe("05bb75f070704371ae568bd2ab39647eab75d1af9dff4bf2bcbce9d8f1c5bb7e44cd2831ed5142d2a04bdd0");
            result.ConnectionStringPassword.ShouldBe("34b49975be934e02b94fe8c21c68253c36bb76398ca44f02b5666d68b310b384fe9163e2c140");
            result.ConnectionStringDataSource.ShouldBe("5bd0d627e5c347ab8b4f648c512");
            result.LogLevel.ShouldBe("c0eeb88176994e2f815bec6ea63b1bd0b9c727f6c82d4f83ad7b4f74d38c2bde46f9afda0f484028bcceee90c8996");
            result.SeverityId.ShouldBe(845674415);
            result.DailyLimit.ShouldBe(376710275);
            result.WeeklyLimit.ShouldBe(425717149);
            result.MonthlyLimit.ShouldBe(817784595);
            result.YearlyLimit.ShouldBe(197193679);
            result.ErrorMessage.ShouldBe("a55da323b97a480ab92e5e5281af6edb8de7ca33d21f4fbdaa747fe6689541ef8827d046fc0544d389fd48e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new OrangeBillPullServiceConfigurationUpdateDto()
            {
                ServiceTypeId = 315507635,
                IsServiceEnabled = true,
                IsWebServiceEnabled = true,
                WebServiceUrl = "3d5bd019fea440aa8feed1e624076f96f5db186f0fa14f1fa12fe90807e5146a1d452f33942845e9ae58",
                StoredProcedureName = "d6a54158d70345e0a9b0cae488866d0d3ba087",
                BillerCode = "a080ec8990554b8da684eec09d7342fa1e827086759a4f3d801741966b96fc53f4e6cc0b45434425a76",
                ConnectionStringUserId = "1b8655fbba18475d9f7cab444883089d180",
                ConnectionStringPassword = "9665a225bfce40f28474f47606",
                ConnectionStringDataSource = "bef6b82521e34eb68cc0c12b99b65c",
                LogLevel = "ecbdc1",
                SeverityId = 1238021819,
                DailyLimit = 924396022,
                WeeklyLimit = 1657058875,
                MonthlyLimit = 1198655428,
                YearlyLimit = 594342582,
                ErrorMessage = "23aaddef8af743cd87a1c0"
            };

            // Act
            var serviceResult = await _orangeBillPullServiceConfigurationsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _orangeBillPullServiceConfigurationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ServiceTypeId.ShouldBe(315507635);
            result.IsServiceEnabled.ShouldBe(true);
            result.IsWebServiceEnabled.ShouldBe(true);
            result.WebServiceUrl.ShouldBe("3d5bd019fea440aa8feed1e624076f96f5db186f0fa14f1fa12fe90807e5146a1d452f33942845e9ae58");
            result.StoredProcedureName.ShouldBe("d6a54158d70345e0a9b0cae488866d0d3ba087");
            result.BillerCode.ShouldBe("a080ec8990554b8da684eec09d7342fa1e827086759a4f3d801741966b96fc53f4e6cc0b45434425a76");
            result.ConnectionStringUserId.ShouldBe("1b8655fbba18475d9f7cab444883089d180");
            result.ConnectionStringPassword.ShouldBe("9665a225bfce40f28474f47606");
            result.ConnectionStringDataSource.ShouldBe("bef6b82521e34eb68cc0c12b99b65c");
            result.LogLevel.ShouldBe("ecbdc1");
            result.SeverityId.ShouldBe(1238021819);
            result.DailyLimit.ShouldBe(924396022);
            result.WeeklyLimit.ShouldBe(1657058875);
            result.MonthlyLimit.ShouldBe(1198655428);
            result.YearlyLimit.ShouldBe(594342582);
            result.ErrorMessage.ShouldBe("23aaddef8af743cd87a1c0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _orangeBillPullServiceConfigurationsAppService.DeleteAsync(1);

            // Assert
            var result = await _orangeBillPullServiceConfigurationRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}