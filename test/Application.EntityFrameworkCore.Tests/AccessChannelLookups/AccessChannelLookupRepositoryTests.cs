using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.AccessChannelLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.AccessChannelLookups
{
    public class AccessChannelLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IAccessChannelLookupRepository _accessChannelLookupRepository;

        public AccessChannelLookupRepositoryTests()
        {
            _accessChannelLookupRepository = GetRequiredService<IAccessChannelLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _accessChannelLookupRepository.GetListAsync(
                    code: "887b69f51",
                    name: "d2966ccbe1f24e638",
                    description: "2f718aaee9184dbeb4c9f4eab6caaf3ec142850335a0460da57e221d9d5a628894e0e1e53572486180f312e"
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
                var result = await _accessChannelLookupRepository.GetCountAsync(
                    code: "c2a27fa4a4864cecbb0499732933485e35b3573734c34b62a51c",
                    name: "5df8437a15d74b18a01048557f65f2cf7c4a33f8ac97416bbc48e54bc3a4ed4ed7e4c337d3",
                    description: "157070a4dca4457ca52212c3c1879928d7497527ae434e20b3ecff4f414eb3c647e5ed65ed"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}