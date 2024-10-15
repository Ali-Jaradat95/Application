using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.PaymentSourceLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.PaymentSourceLookups
{
    public class PaymentSourceLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IPaymentSourceLookupRepository _paymentSourceLookupRepository;

        public PaymentSourceLookupRepositoryTests()
        {
            _paymentSourceLookupRepository = GetRequiredService<IPaymentSourceLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _paymentSourceLookupRepository.GetListAsync(
                    code: "af733c8f507944dfa2126312a9f3d2ad306ea2fed40d447a94d37926ffbeb69c8d38a32038b043ed9c6f5fb59ff",
                    name: "456268aeed9544519ce94907460df6474a50023b1c4142d7b00826e7733960a184a43cfcaf6a4513a52240e250cd112",
                    description: "4086458d156342e680e8013ddc89de17af32b185"
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
                var result = await _paymentSourceLookupRepository.GetCountAsync(
                    code: "3e872e6762c74f70b56b7f31ef2edd7813d57f8be45b458e83213251bd11e57d2b6c3eaae4da4d",
                    name: "1b02a1ed58f142a19f14ace605f06c932bef79ab23474",
                    description: "1e899a2a4a5c4b93adee7ea2ae5fafeb4108db82537a465b88"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}