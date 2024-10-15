using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.ThresholdLookups
{
    public class ThresholdLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IThresholdLookupsAppService _thresholdLookupsAppService;
        private readonly IRepository<ThresholdLookup, int> _thresholdLookupRepository;

        public ThresholdLookupsAppServiceTests()
        {
            _thresholdLookupsAppService = GetRequiredService<IThresholdLookupsAppService>();
            _thresholdLookupRepository = GetRequiredService<IRepository<ThresholdLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _thresholdLookupsAppService.GetListAsync(new GetThresholdLookupsInput());

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
            var result = await _thresholdLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ThresholdLookupCreateDto
            {
                Code = "85dd6b6ec8f54e0abd1588c39109fe",
                Name = "2c224690dacf40e3a798c67a410824a95dfd9ecf55d34ce086c3da",
                Description = "9489414ff3f649bd8396c14306029714ca63128bcc5f45"
            };

            // Act
            var serviceResult = await _thresholdLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _thresholdLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("85dd6b6ec8f54e0abd1588c39109fe");
            result.Name.ShouldBe("2c224690dacf40e3a798c67a410824a95dfd9ecf55d34ce086c3da");
            result.Description.ShouldBe("9489414ff3f649bd8396c14306029714ca63128bcc5f45");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ThresholdLookupUpdateDto()
            {
                Code = "905b7ead0f814b38be673ce8befc5227b05774aa4f514d93beab17d6917f2f20401d97351d814368a1944",
                Name = "808938ea10834774b5a6dd8c2e1471505c434675aac3415294afe",
                Description = "20c347a0bc8243bca18862869bd"
            };

            // Act
            var serviceResult = await _thresholdLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _thresholdLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("905b7ead0f814b38be673ce8befc5227b05774aa4f514d93beab17d6917f2f20401d97351d814368a1944");
            result.Name.ShouldBe("808938ea10834774b5a6dd8c2e1471505c434675aac3415294afe");
            result.Description.ShouldBe("20c347a0bc8243bca18862869bd");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _thresholdLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _thresholdLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}