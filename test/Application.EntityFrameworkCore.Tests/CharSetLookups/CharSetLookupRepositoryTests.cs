using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.CharSetLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.CharSetLookups
{
    public class CharSetLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly ICharSetLookupRepository _charSetLookupRepository;

        public CharSetLookupRepositoryTests()
        {
            _charSetLookupRepository = GetRequiredService<ICharSetLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _charSetLookupRepository.GetListAsync(
                    code: "cd48d01492374e9893280ae111db5d79a0654451a2634827b65720296f2e5efa",
                    name: "753afacffed143ee98a9bb3c3ea2eb041c8caee",
                    description: "48d64832979a4e8f99027d25477217e"
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
                var result = await _charSetLookupRepository.GetCountAsync(
                    code: "460e21d981d74da6a724bbe8b0b4e11d6e356dbdec274c0491384dacecbd26eb3c467db25621485e8",
                    name: "7bd6a4dc509b46d7ac0ac94ade05144d1d",
                    description: "5cebe6fdd6be4b3f9"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}