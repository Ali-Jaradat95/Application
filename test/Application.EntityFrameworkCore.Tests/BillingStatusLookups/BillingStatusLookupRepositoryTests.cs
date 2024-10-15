using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.BillingStatusLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.BillingStatusLookups
{
    public class BillingStatusLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IBillingStatusLookupRepository _billingStatusLookupRepository;

        public BillingStatusLookupRepositoryTests()
        {
            _billingStatusLookupRepository = GetRequiredService<IBillingStatusLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _billingStatusLookupRepository.GetListAsync(
                    code: "bcbca878259848cc9337818303f891572b440c0ab7044d3bb8900ee42cd8affaa1f8f7f1ac664",
                    name: "db1a13eb7cb8",
                    description: "54ac097557b1401abfe25debc7b45dc8915111d60aec476cb5996ee73f2366b139ad6a4ed"
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
                var result = await _billingStatusLookupRepository.GetCountAsync(
                    code: "5e23b2cc6670400f93c3ca55d667831e691645a70b0b4cd4a403d3a7f9d1af144dfd744f5a0749",
                    name: "d2cb1b17131445c6a56f166d3f04ff31a6b8369f84a744078a",
                    description: "a6c6cfc2a29c4ed0819aedb78f91289f1aea"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}