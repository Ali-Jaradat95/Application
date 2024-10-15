using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.LanguageIsoNameLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.LanguageIsoNameLookups
{
    public class LanguageIsoNameLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly ILanguageIsoNameLookupRepository _languageIsoNameLookupRepository;

        public LanguageIsoNameLookupRepositoryTests()
        {
            _languageIsoNameLookupRepository = GetRequiredService<ILanguageIsoNameLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _languageIsoNameLookupRepository.GetListAsync(
                    code: "ad3bda60598a4305a91d7d4fac86e04b589c3de7e1",
                    name: "0b06f45188824a1ebf70710b67b337f08933c6c2d30c4ca7ab9136b432c876337df529cd74234e9381d8978",
                    description: "17fd52c84ba34996a78119684967bd"
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
                var result = await _languageIsoNameLookupRepository.GetCountAsync(
                    code: "7d1dc5fbe455",
                    name: "4e027cfc96e94d4fa68b935a048ffe531a4b33100b8344d9818955d4b938ecc9ef930feb42",
                    description: "3314c655eb2c4350a348d4882c8b8eaadd1d84c3aac5495bae5909cd14dfe8731186b7a306df"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}