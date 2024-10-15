using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.SeverityLookups
{
    public class SeverityLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly ISeverityLookupsAppService _severityLookupsAppService;
        private readonly IRepository<SeverityLookup, int> _severityLookupRepository;

        public SeverityLookupsAppServiceTests()
        {
            _severityLookupsAppService = GetRequiredService<ISeverityLookupsAppService>();
            _severityLookupRepository = GetRequiredService<IRepository<SeverityLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _severityLookupsAppService.GetListAsync(new GetSeverityLookupsInput());

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
            var result = await _severityLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SeverityLookupCreateDto
            {
                Code = "e5b1b9281ec94b49bf6ba3d7b8eec",
                Name = "c5b28e10065a4275bb4f6f8ae191be82e49bbb5fdbe",
                Description = "b903abf"
            };

            // Act
            var serviceResult = await _severityLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _severityLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("e5b1b9281ec94b49bf6ba3d7b8eec");
            result.Name.ShouldBe("c5b28e10065a4275bb4f6f8ae191be82e49bbb5fdbe");
            result.Description.ShouldBe("b903abf");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SeverityLookupUpdateDto()
            {
                Code = "7f3bdd4f73d24e0c8efd495fbfbda68f2e0861cb12084c22ac7be90e0bad",
                Name = "bdb6e0405",
                Description = "78a76565fb4046ac97c19274afabdece3f1698dc5"
            };

            // Act
            var serviceResult = await _severityLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _severityLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("7f3bdd4f73d24e0c8efd495fbfbda68f2e0861cb12084c22ac7be90e0bad");
            result.Name.ShouldBe("bdb6e0405");
            result.Description.ShouldBe("78a76565fb4046ac97c19274afabdece3f1698dc5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _severityLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _severityLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}