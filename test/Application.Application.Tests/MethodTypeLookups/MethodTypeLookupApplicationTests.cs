using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.MethodTypeLookups
{
    public class MethodTypeLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IMethodTypeLookupsAppService _methodTypeLookupsAppService;
        private readonly IRepository<MethodTypeLookup, int> _methodTypeLookupRepository;

        public MethodTypeLookupsAppServiceTests()
        {
            _methodTypeLookupsAppService = GetRequiredService<IMethodTypeLookupsAppService>();
            _methodTypeLookupRepository = GetRequiredService<IRepository<MethodTypeLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _methodTypeLookupsAppService.GetListAsync(new GetMethodTypeLookupsInput());

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
            var result = await _methodTypeLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MethodTypeLookupCreateDto
            {
                Code = "b8aaaf72b1084fdbacd4a5cb0c4d766b94c2fc2e46b14e878afd6ab054a38299c5f1b53b912c",
                Name = "dd1b486737d24e679441a71093080f1f1f517517acd845338846eaee4f0cf403b636",
                Description = "a5afbb4ae86b4de999c47ef47330103b7dc7774f35f8419da7a3e"
            };

            // Act
            var serviceResult = await _methodTypeLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _methodTypeLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("b8aaaf72b1084fdbacd4a5cb0c4d766b94c2fc2e46b14e878afd6ab054a38299c5f1b53b912c");
            result.Name.ShouldBe("dd1b486737d24e679441a71093080f1f1f517517acd845338846eaee4f0cf403b636");
            result.Description.ShouldBe("a5afbb4ae86b4de999c47ef47330103b7dc7774f35f8419da7a3e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MethodTypeLookupUpdateDto()
            {
                Code = "4c7eb7a5b69b40cda79fe0c1a711a2be1015bc024221499bb01fae502e0858b49a3c2165c3124bbd8bb236cf07",
                Name = "270341c43b09438ca3d1e0837c06823cbb3d66e66657468d987b1b7c5cc35140cfc9962f8b034811be9aab37b09489eb",
                Description = "88d836028d79464fa5917a6341d420775b7f01e6b7464705951431fc8327ad066a3939"
            };

            // Act
            var serviceResult = await _methodTypeLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _methodTypeLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("4c7eb7a5b69b40cda79fe0c1a711a2be1015bc024221499bb01fae502e0858b49a3c2165c3124bbd8bb236cf07");
            result.Name.ShouldBe("270341c43b09438ca3d1e0837c06823cbb3d66e66657468d987b1b7c5cc35140cfc9962f8b034811be9aab37b09489eb");
            result.Description.ShouldBe("88d836028d79464fa5917a6341d420775b7f01e6b7464705951431fc8327ad066a3939");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _methodTypeLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _methodTypeLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}