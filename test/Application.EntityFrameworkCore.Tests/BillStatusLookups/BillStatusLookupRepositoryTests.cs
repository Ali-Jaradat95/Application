using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.BillStatusLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.BillStatusLookups
{
    public class BillStatusLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IBillStatusLookupRepository _billStatusLookupRepository;

        public BillStatusLookupRepositoryTests()
        {
            _billStatusLookupRepository = GetRequiredService<IBillStatusLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _billStatusLookupRepository.GetListAsync(
                    code: "ebf0c5cc73a14f0f8ff9fb82",
                    name: "6562958794c64ea69a8e3f450edfc611d2bc0ab70ee94290b0425a613784b78763ab46e0a9db",
                    description: "4632a734bd974962bf890da28e0b33ffecec5a3705c14d8594ba3e7eb6c553b89cc3bc953dd84d77810913cacc25dffd"
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
                var result = await _billStatusLookupRepository.GetCountAsync(
                    code: "a8fc55f2c9ca4be298ffd1ecdeec589c5beec051b3b9426cafbc9084",
                    name: "1149ff3265ee42a286d709852ef63138922b0442b7464732a56e9e8",
                    description: "090b51e0596"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}