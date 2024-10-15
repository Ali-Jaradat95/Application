using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.OrangeBillPaymentNotificationConfigurations;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public class OrangeBillPaymentNotificationConfigurationRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IOrangeBillPaymentNotificationConfigurationRepository _orangeBillPaymentNotificationConfigurationRepository;

        public OrangeBillPaymentNotificationConfigurationRepositoryTests()
        {
            _orangeBillPaymentNotificationConfigurationRepository = GetRequiredService<IOrangeBillPaymentNotificationConfigurationRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _orangeBillPaymentNotificationConfigurationRepository.GetListAsync(
                    serviceTypeName: "9d3aba65e58946059677e92d7d543de92e6c95989d8748cc8",
                    configurationKey: "8b8066c6f706417aa8ae39b04f416dd16486c7de7f4844648c4dd0d8321",
                    configurationValue: "e980c757642d41a8b61ab8c0713e9374c3"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _orangeBillPaymentNotificationConfigurationRepository.GetCountAsync(
                    serviceTypeName: "fdf56efbe9ab40018f2a80a",
                    configurationKey: "dd9d58127ea941e1b90",
                    configurationValue: "6965deb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}