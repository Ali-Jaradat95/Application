using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public class OrangeBillPaymentNotificationConfigurationsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IOrangeBillPaymentNotificationConfigurationsAppService _orangeBillPaymentNotificationConfigurationsAppService;
        private readonly IRepository<OrangeBillPaymentNotificationConfiguration, int> _orangeBillPaymentNotificationConfigurationRepository;

        public OrangeBillPaymentNotificationConfigurationsAppServiceTests()
        {
            _orangeBillPaymentNotificationConfigurationsAppService = GetRequiredService<IOrangeBillPaymentNotificationConfigurationsAppService>();
            _orangeBillPaymentNotificationConfigurationRepository = GetRequiredService<IRepository<OrangeBillPaymentNotificationConfiguration, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _orangeBillPaymentNotificationConfigurationsAppService.GetListAsync(new GetOrangeBillPaymentNotificationConfigurationsInput());

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
            var result = await _orangeBillPaymentNotificationConfigurationsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new OrangeBillPaymentNotificationConfigurationCreateDto
            {
                ServiceTypeName = "a514a292e445400db4c5a74a84881a12639d5c59ae5d4b47a3b8e4c19fdc489f398a6",
                ConfigurationKey = "07a8bc59c6924f8c822548bbb71b",
                ConfigurationValue = "159b775b211746dba2ff3b49e6b5dffff73d7b448d894d689c100d9c22c0aedda4119904a46c480f93"
            };

            // Act
            var serviceResult = await _orangeBillPaymentNotificationConfigurationsAppService.CreateAsync(input);

            // Assert
            var result = await _orangeBillPaymentNotificationConfigurationRepository.FindAsync(c => c.ServiceTypeName == serviceResult.ServiceTypeName);

            result.ShouldNotBe(null);
            result.ServiceTypeName.ShouldBe("a514a292e445400db4c5a74a84881a12639d5c59ae5d4b47a3b8e4c19fdc489f398a6");
            result.ConfigurationKey.ShouldBe("07a8bc59c6924f8c822548bbb71b");
            result.ConfigurationValue.ShouldBe("159b775b211746dba2ff3b49e6b5dffff73d7b448d894d689c100d9c22c0aedda4119904a46c480f93");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new OrangeBillPaymentNotificationConfigurationUpdateDto()
            {
                ServiceTypeName = "efc71c725eab4aaf9c02663fc99e70ad74c9b481e3b342328d24c7b9ca49ab2a1bd353ae08b",
                ConfigurationKey = "7f396dbee8844eae99b52c063dff098a3d5184f0e9e24a2b9",
                ConfigurationValue = "a4277ce4b1f74ae49fa10a5525d3e"
            };

            // Act
            var serviceResult = await _orangeBillPaymentNotificationConfigurationsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _orangeBillPaymentNotificationConfigurationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ServiceTypeName.ShouldBe("efc71c725eab4aaf9c02663fc99e70ad74c9b481e3b342328d24c7b9ca49ab2a1bd353ae08b");
            result.ConfigurationKey.ShouldBe("7f396dbee8844eae99b52c063dff098a3d5184f0e9e24a2b9");
            result.ConfigurationValue.ShouldBe("a4277ce4b1f74ae49fa10a5525d3e");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _orangeBillPaymentNotificationConfigurationsAppService.DeleteAsync(1);

            // Assert
            var result = await _orangeBillPaymentNotificationConfigurationRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}