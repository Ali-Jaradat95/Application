using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.PaymentStatusLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.PaymentStatusLookups
{
    public class PaymentStatusLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IPaymentStatusLookupRepository _paymentStatusLookupRepository;

        public PaymentStatusLookupRepositoryTests()
        {
            _paymentStatusLookupRepository = GetRequiredService<IPaymentStatusLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _paymentStatusLookupRepository.GetListAsync(
                    code: "e4ea293997dd407ba30fd895b4c8dab95e074a4dc2564e3fa9bd2819559179d",
                    name: "827d46bac65342dabd1f8cdd7a7972fa9164e6092",
                    description: "63ab9a9c49e14c6286c7"
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
                var result = await _paymentStatusLookupRepository.GetCountAsync(
                    code: "7fb1e1428c06426f92a5772722e48898fcce4c4c3af346e4922b70bb6261b957a80323dbeb0a45f79",
                    name: "df6a32bbcaf34f08a28d6b28a92c7ab4f733953aa07842",
                    description: "c9095fe1e6594a8b8de85957766ec8aa4a74f422fd66480bb4cb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}