using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.PaymentTypeLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.PaymentTypeLookups
{
    public class PaymentTypeLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IPaymentTypeLookupRepository _paymentTypeLookupRepository;

        public PaymentTypeLookupRepositoryTests()
        {
            _paymentTypeLookupRepository = GetRequiredService<IPaymentTypeLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _paymentTypeLookupRepository.GetListAsync(
                    code: "c30e5729f2f7484c932eaf5afc8aeb3935d75038b7274e34abea482730528b4",
                    name: "a4ff6f85428047918a1488262e5e5123ff0d2cc2c2614911a103814e569925ba4d7ad53377a9407897cd5139423be3d",
                    description: "8f96b352269d4972b185b0c781ac64ac48d1a4d0846349cbaf3e7b9f351c49edb07"
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
                var result = await _paymentTypeLookupRepository.GetCountAsync(
                    code: "ebeaf2c07aa443408038f8d9271e1a00a1a0644e07784071a1fb5b1f75983e35c23e648468784fc9b0",
                    name: "51076733fbae4192a7240dfa16eb4219c6cd2489fa914cfaa2cb49d6c3c5fc5d64eac78774f84",
                    description: "5a22e938599646d0bc25e011c3fc12a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}