using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.PaymentMethodLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.PaymentMethodLookups
{
    public class PaymentMethodLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IPaymentMethodLookupRepository _paymentMethodLookupRepository;

        public PaymentMethodLookupRepositoryTests()
        {
            _paymentMethodLookupRepository = GetRequiredService<IPaymentMethodLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _paymentMethodLookupRepository.GetListAsync(
                    code: "e3e6ecffd02c455d9984ee9bca6f2824c90c45c3ad114f9a8029cead201a",
                    name: "03d57166e8ed4dc99bf755e6d1076001a0123f5767734ce69c5ff73a29262eebcd877",
                    description: "fb22c4752386414f824334eaea557df840b3ed4867054eada4c025974562b62f6973c66373e4485d93c3c29fbca"
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
                var result = await _paymentMethodLookupRepository.GetCountAsync(
                    code: "92cbeb5e30314ed09c7dd3b46cb113f83264320b4cda4d4",
                    name: "2bc5cd14916a4455a",
                    description: "cac0479496e04a83a6a4feeddcb8634d7b15"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}