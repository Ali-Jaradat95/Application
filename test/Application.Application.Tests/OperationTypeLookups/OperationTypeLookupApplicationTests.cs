using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.OperationTypeLookups
{
    public class OperationTypeLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IOperationTypeLookupsAppService _operationTypeLookupsAppService;
        private readonly IRepository<OperationTypeLookup, int> _operationTypeLookupRepository;

        public OperationTypeLookupsAppServiceTests()
        {
            _operationTypeLookupsAppService = GetRequiredService<IOperationTypeLookupsAppService>();
            _operationTypeLookupRepository = GetRequiredService<IRepository<OperationTypeLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _operationTypeLookupsAppService.GetListAsync(new GetOperationTypeLookupsInput());

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
            var result = await _operationTypeLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new OperationTypeLookupCreateDto
            {
                Code = "5640c5e079974c5491707c2d5ffe27a9a316707abe7f45a1b21ef034017614dcecddb4b79",
                Name = "60665edccc5b482d9f5cabe74f20b45",
                Description = "161b5764a35545dcb9a"
            };

            // Act
            var serviceResult = await _operationTypeLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _operationTypeLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("5640c5e079974c5491707c2d5ffe27a9a316707abe7f45a1b21ef034017614dcecddb4b79");
            result.Name.ShouldBe("60665edccc5b482d9f5cabe74f20b45");
            result.Description.ShouldBe("161b5764a35545dcb9a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new OperationTypeLookupUpdateDto()
            {
                Code = "bff4de2f36d34c76b0d8fe398e13d54059424de3e5c842e6974b161827e62cdb9",
                Name = "b6e41f4bf1944427",
                Description = "d461e7b14a404d80af3beed5bd09ce"
            };

            // Act
            var serviceResult = await _operationTypeLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _operationTypeLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("bff4de2f36d34c76b0d8fe398e13d54059424de3e5c842e6974b161827e62cdb9");
            result.Name.ShouldBe("b6e41f4bf1944427");
            result.Description.ShouldBe("d461e7b14a404d80af3beed5bd09ce");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _operationTypeLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _operationTypeLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}