using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.BillTypeLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.BillTypeLookups
{
    public class BillTypeLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IBillTypeLookupRepository _billTypeLookupRepository;

        public BillTypeLookupRepositoryTests()
        {
            _billTypeLookupRepository = GetRequiredService<IBillTypeLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _billTypeLookupRepository.GetListAsync(
                    code: "5e7346e22b7846",
                    name: "0141d10b736645c599ba6b0745d617b87f61cc1ffbc",
                    description: "800e15a9f51e4d"
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
                var result = await _billTypeLookupRepository.GetCountAsync(
                    code: "a4968b7af99749d39c1364d8ec596ce127eed2afd0f54702b4f3e95d2394b525730b3082a65f4cd18ce3c",
                    name: "4f914741e92c4d6fabeeeacaecd892700",
                    description: "4e77a370053c4a11939b3"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}