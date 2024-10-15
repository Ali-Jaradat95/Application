using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.ServiceTypeLookups
{
    public class ServiceTypeLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IServiceTypeLookupsAppService _serviceTypeLookupsAppService;
        private readonly IRepository<ServiceTypeLookup, int> _serviceTypeLookupRepository;

        public ServiceTypeLookupsAppServiceTests()
        {
            _serviceTypeLookupsAppService = GetRequiredService<IServiceTypeLookupsAppService>();
            _serviceTypeLookupRepository = GetRequiredService<IRepository<ServiceTypeLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _serviceTypeLookupsAppService.GetListAsync(new GetServiceTypeLookupsInput());

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
            var result = await _serviceTypeLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ServiceTypeLookupCreateDto
            {
                Code = "d516a49846974c5f99af7cbe2498bcca662a8fd923774f789d349fe1ad9fd9663fb0b91be38d46e59eb2b9680",
                Name = "a88cd6083",
                Description = "8702cafb8c494fcd991fbb53c1616c10a301"
            };

            // Act
            var serviceResult = await _serviceTypeLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _serviceTypeLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("d516a49846974c5f99af7cbe2498bcca662a8fd923774f789d349fe1ad9fd9663fb0b91be38d46e59eb2b9680");
            result.Name.ShouldBe("a88cd6083");
            result.Description.ShouldBe("8702cafb8c494fcd991fbb53c1616c10a301");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ServiceTypeLookupUpdateDto()
            {
                Code = "cf199a18d8c24968b",
                Name = "89ada2f9cf5e4c968a4e1badbf111ce9b887021405ec4ac1af2450b38d69c51da289a1ad53c14f3dacb9b15e5a35",
                Description = "829f9b04ac844a43baa37f45f38831810e48d6326d07486f8a06bc5b7afe"
            };

            // Act
            var serviceResult = await _serviceTypeLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _serviceTypeLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("cf199a18d8c24968b");
            result.Name.ShouldBe("89ada2f9cf5e4c968a4e1badbf111ce9b887021405ec4ac1af2450b38d69c51da289a1ad53c14f3dacb9b15e5a35");
            result.Description.ShouldBe("829f9b04ac844a43baa37f45f38831810e48d6326d07486f8a06bc5b7afe");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _serviceTypeLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _serviceTypeLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}