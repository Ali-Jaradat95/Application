using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.ProcessStatusLookups
{
    public class ProcessStatusLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IProcessStatusLookupsAppService _processStatusLookupsAppService;
        private readonly IRepository<ProcessStatusLookup, int> _processStatusLookupRepository;

        public ProcessStatusLookupsAppServiceTests()
        {
            _processStatusLookupsAppService = GetRequiredService<IProcessStatusLookupsAppService>();
            _processStatusLookupRepository = GetRequiredService<IRepository<ProcessStatusLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _processStatusLookupsAppService.GetListAsync(new GetProcessStatusLookupsInput());

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
            var result = await _processStatusLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ProcessStatusLookupCreateDto
            {
                Code = "2b31104a63334bf697b8f9625a1a580b981e99c0fbeb4fa0a",
                Name = "963555f3dafa42f5a7de1df237a7a8f5b0c0fbfe91af454c9b6a64c3d62e",
                Description = "d6593cd660954a789c201c69fd6f9f015b23873"
            };

            // Act
            var serviceResult = await _processStatusLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _processStatusLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("2b31104a63334bf697b8f9625a1a580b981e99c0fbeb4fa0a");
            result.Name.ShouldBe("963555f3dafa42f5a7de1df237a7a8f5b0c0fbfe91af454c9b6a64c3d62e");
            result.Description.ShouldBe("d6593cd660954a789c201c69fd6f9f015b23873");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ProcessStatusLookupUpdateDto()
            {
                Code = "28bd72116ec24775897e42ae313a2876831cbc9d7ed94146b2084b0f631c329b4066678f24f446a49680eff2bbe0192db98",
                Name = "49ea56bac30c40b89170fc3065f0f4dc680d5ecae5914d27",
                Description = "740a7b121c3548fe8ac7592042f01afc662c232a69c"
            };

            // Act
            var serviceResult = await _processStatusLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _processStatusLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("28bd72116ec24775897e42ae313a2876831cbc9d7ed94146b2084b0f631c329b4066678f24f446a49680eff2bbe0192db98");
            result.Name.ShouldBe("49ea56bac30c40b89170fc3065f0f4dc680d5ecae5914d27");
            result.Description.ShouldBe("740a7b121c3548fe8ac7592042f01afc662c232a69c");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _processStatusLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _processStatusLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}