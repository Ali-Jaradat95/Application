using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.ThresholdLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.ThresholdLookups
{
    public class ThresholdLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IThresholdLookupRepository _thresholdLookupRepository;

        public ThresholdLookupRepositoryTests()
        {
            _thresholdLookupRepository = GetRequiredService<IThresholdLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _thresholdLookupRepository.GetListAsync(
                    code: "dc44b242400d4ce289d25f271fe6c90b0f18c792b96141e19cb97bf8a388d80828fd5389b514486597c668412",
                    name: "f0826a38b7ae41e2b23164ee6b9f3",
                    description: "fb91c2dd88c14e0b855fa44168d0ed38dab8f7536da0485f8a1866b949a25033b827127a27dc4"
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
                var result = await _thresholdLookupRepository.GetCountAsync(
                    code: "b704c73da6f0467692255b7954cb9f9303cce94705974c84a33b6909f47c7dd5a12d14aa96bd43f383721e8c5f93b",
                    name: "ffb3f1081c5e4de4be1f95f218bd096bd850a5328bd9426281aee5e73f64ef98c9f0366a4b384e7193dc4c1",
                    description: "872fbb4e6d4c49d595c253a3053844c9"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}