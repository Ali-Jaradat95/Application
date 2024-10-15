using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.CharSetLookups
{
    public class CharSetLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly ICharSetLookupsAppService _charSetLookupsAppService;
        private readonly IRepository<CharSetLookup, int> _charSetLookupRepository;

        public CharSetLookupsAppServiceTests()
        {
            _charSetLookupsAppService = GetRequiredService<ICharSetLookupsAppService>();
            _charSetLookupRepository = GetRequiredService<IRepository<CharSetLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _charSetLookupsAppService.GetListAsync(new GetCharSetLookupsInput());

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
            var result = await _charSetLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CharSetLookupCreateDto
            {
                Code = "2e68db2099544105bf08afc9d4afd",
                Name = "cb23d4e712504131b26b59afdfa26fe12d283b62b8e540578039074caecd37e0bea8b68bcef743c",
                Description = "5edd0403acc9412396e2f7e79f6b64c1d10e7bd261384dc9a141be5efa6db713be70570a8a714b7bbbb43bb2ce"
            };

            // Act
            var serviceResult = await _charSetLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _charSetLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("2e68db2099544105bf08afc9d4afd");
            result.Name.ShouldBe("cb23d4e712504131b26b59afdfa26fe12d283b62b8e540578039074caecd37e0bea8b68bcef743c");
            result.Description.ShouldBe("5edd0403acc9412396e2f7e79f6b64c1d10e7bd261384dc9a141be5efa6db713be70570a8a714b7bbbb43bb2ce");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CharSetLookupUpdateDto()
            {
                Code = "456ea4c1c20a4ded9deada9d614076174d3f91ffd1e94aa69e79a36d51c6c269228caafdae7e484e91075d1f39d",
                Name = "09d5755452d843a89dc369807b93ecd69c74674d",
                Description = "ebeab6fd8da441"
            };

            // Act
            var serviceResult = await _charSetLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _charSetLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("456ea4c1c20a4ded9deada9d614076174d3f91ffd1e94aa69e79a36d51c6c269228caafdae7e484e91075d1f39d");
            result.Name.ShouldBe("09d5755452d843a89dc369807b93ecd69c74674d");
            result.Description.ShouldBe("ebeab6fd8da441");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _charSetLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _charSetLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}