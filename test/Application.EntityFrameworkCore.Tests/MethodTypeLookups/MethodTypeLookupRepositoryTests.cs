using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.MethodTypeLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.MethodTypeLookups
{
    public class MethodTypeLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IMethodTypeLookupRepository _methodTypeLookupRepository;

        public MethodTypeLookupRepositoryTests()
        {
            _methodTypeLookupRepository = GetRequiredService<IMethodTypeLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _methodTypeLookupRepository.GetListAsync(
                    code: "98553aa4c1984008ab1f22d3e0e8208ae15ed02ee71e47a5a21704ed5bae25ed1c01d54979e64b88",
                    name: "ebfa4e6983f24d0197406699ab82e36daa399b123e2b4e9187d99837e",
                    description: "5ed55e37120a4258a787f37a67309ad0b66e165835734804b7160485d36e086055cb8b61a37c41868b1d"
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
                var result = await _methodTypeLookupRepository.GetCountAsync(
                    code: "b0fad612907645aea24f0dadd30fa47075aab5c7ce214294a19a2d09fd550a1a517fd30688524e3b9b6f5",
                    name: "cb742cb3fd7f4c53b8d4054595da059af102ef7648cf4f199f880ae8aa7cd07f6bbf00",
                    description: "dc0aea9e55974902ae71fface9c9aedc7921a815e7f44da6a694710e34fda539e34b6cd5d7004"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}