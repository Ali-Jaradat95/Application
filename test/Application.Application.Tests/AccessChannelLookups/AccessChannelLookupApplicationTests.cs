using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.AccessChannelLookups
{
    public class AccessChannelLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IAccessChannelLookupsAppService _accessChannelLookupsAppService;
        private readonly IRepository<AccessChannelLookup, int> _accessChannelLookupRepository;

        public AccessChannelLookupsAppServiceTests()
        {
            _accessChannelLookupsAppService = GetRequiredService<IAccessChannelLookupsAppService>();
            _accessChannelLookupRepository = GetRequiredService<IRepository<AccessChannelLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _accessChannelLookupsAppService.GetListAsync(new GetAccessChannelLookupsInput());

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
            var result = await _accessChannelLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new AccessChannelLookupCreateDto
            {
                Code = "a545a6d97e2d4123a951093fddda5833592a9198330c49a797207dd5dbaaae08f7d7414f106d452e9b22a44418b",
                Name = "e7af94123dd8456c95038c14024aa6e8d3bee139df184eb398a42",
                Description = "cc30ee7786cf424eb0114e40a928d51eb0d26e44e0904d2492c0454ede814c8e3f62d3f40f254246a8c1"
            };

            // Act
            var serviceResult = await _accessChannelLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _accessChannelLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("a545a6d97e2d4123a951093fddda5833592a9198330c49a797207dd5dbaaae08f7d7414f106d452e9b22a44418b");
            result.Name.ShouldBe("e7af94123dd8456c95038c14024aa6e8d3bee139df184eb398a42");
            result.Description.ShouldBe("cc30ee7786cf424eb0114e40a928d51eb0d26e44e0904d2492c0454ede814c8e3f62d3f40f254246a8c1");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new AccessChannelLookupUpdateDto()
            {
                Code = "619141b6a79c4039bdff310048cd3c5e50fec96d3df2425a86b9795e04f0b7a0a6ff19f04f0f457",
                Name = "d8a7a509168349718cf131ef1f1d61a3aca7ec",
                Description = "e5b03e478e6d4bd3a66d5f75a9da55ba70c8f120be9b48f681897d89f66d426218ddb3a0c0534e1299"
            };

            // Act
            var serviceResult = await _accessChannelLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _accessChannelLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("619141b6a79c4039bdff310048cd3c5e50fec96d3df2425a86b9795e04f0b7a0a6ff19f04f0f457");
            result.Name.ShouldBe("d8a7a509168349718cf131ef1f1d61a3aca7ec");
            result.Description.ShouldBe("e5b03e478e6d4bd3a66d5f75a9da55ba70c8f120be9b48f681897d89f66d426218ddb3a0c0534e1299");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _accessChannelLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _accessChannelLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}