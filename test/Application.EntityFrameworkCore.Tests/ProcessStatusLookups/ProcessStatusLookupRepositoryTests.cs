using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.ProcessStatusLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.ProcessStatusLookups
{
    public class ProcessStatusLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IProcessStatusLookupRepository _processStatusLookupRepository;

        public ProcessStatusLookupRepositoryTests()
        {
            _processStatusLookupRepository = GetRequiredService<IProcessStatusLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _processStatusLookupRepository.GetListAsync(
                    code: "05555adf786f4665aba14ae555058f2a80a70e927bbe41968a186064ec58660a1678e6ccea4c48d1b38",
                    name: "959237",
                    description: "f8cf0985771"
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
                var result = await _processStatusLookupRepository.GetCountAsync(
                    code: "0b94dc3acf",
                    name: "c9e729f412da4088964c0379b2b533bcc5577cb4b4764066a985d965a78288244984690437404aae918805447b34b618519",
                    description: "87a906e271a640ababde8aed7af04d49833e9844674f461b95dcc15311a8251336b1a18f7a224033b298d4"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}