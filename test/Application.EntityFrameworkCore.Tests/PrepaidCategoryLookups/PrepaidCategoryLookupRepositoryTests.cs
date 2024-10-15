using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.PrepaidCategoryLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.PrepaidCategoryLookups
{
    public class PrepaidCategoryLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IPrepaidCategoryLookupRepository _prepaidCategoryLookupRepository;

        public PrepaidCategoryLookupRepositoryTests()
        {
            _prepaidCategoryLookupRepository = GetRequiredService<IPrepaidCategoryLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _prepaidCategoryLookupRepository.GetListAsync(
                    code: "df23c7f6538f408f8f6c7bc17fbd211ea23bb1610cf844f2a1308a0f1f696cd93490942d82d941c3bcc35a4",
                    name: "5686feab0efb48",
                    description: "467c211d224c4dd09e750455abee070397e5e75"
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
                var result = await _prepaidCategoryLookupRepository.GetCountAsync(
                    code: "836e46df9feb4f83a054b5f6d8afb05cec2e31287d0443bebcabfa66518904f12f67f6214b",
                    name: "cc3eccc54a6b46c8b958bcceacdf8d4309507103c68d4dff86601f6e5ae4e",
                    description: "8a86d097f3fe441e93a19a1094cf3cda9a6ad4a403d7414498066af3dcfafe704f336dcf97ec44239beed94851"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}