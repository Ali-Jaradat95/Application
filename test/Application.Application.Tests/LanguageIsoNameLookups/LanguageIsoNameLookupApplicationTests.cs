using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.LanguageIsoNameLookups
{
    public class LanguageIsoNameLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly ILanguageIsoNameLookupsAppService _languageIsoNameLookupsAppService;
        private readonly IRepository<LanguageIsoNameLookup, int> _languageIsoNameLookupRepository;

        public LanguageIsoNameLookupsAppServiceTests()
        {
            _languageIsoNameLookupsAppService = GetRequiredService<ILanguageIsoNameLookupsAppService>();
            _languageIsoNameLookupRepository = GetRequiredService<IRepository<LanguageIsoNameLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _languageIsoNameLookupsAppService.GetListAsync(new GetLanguageIsoNameLookupsInput());

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
            var result = await _languageIsoNameLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new LanguageIsoNameLookupCreateDto
            {
                Code = "e1609a28928e4d6f8dfe18cee2577c2806dc46f9c0b0418b9952",
                Name = "57247bd66f3c47e1a9af1a70ad2b29d920d21f5dd7314692a0fe461b28ad1b846ffd3cb53699453ea975b763",
                Description = "94ef3fea6c134503867f"
            };

            // Act
            var serviceResult = await _languageIsoNameLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _languageIsoNameLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("e1609a28928e4d6f8dfe18cee2577c2806dc46f9c0b0418b9952");
            result.Name.ShouldBe("57247bd66f3c47e1a9af1a70ad2b29d920d21f5dd7314692a0fe461b28ad1b846ffd3cb53699453ea975b763");
            result.Description.ShouldBe("94ef3fea6c134503867f");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new LanguageIsoNameLookupUpdateDto()
            {
                Code = "a75db93bd73a4a7a875caed28e1eca9c1ac29fd8248240f4abac798df414dac2b81957d462fb4565b2",
                Name = "6dfb2e39a06c448d89acb0d410d1147eed7d62",
                Description = "712a2e4aaa1748648af183126dc0cd291b8c280ea77a44e9a99fb9eb83305feb"
            };

            // Act
            var serviceResult = await _languageIsoNameLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _languageIsoNameLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("a75db93bd73a4a7a875caed28e1eca9c1ac29fd8248240f4abac798df414dac2b81957d462fb4565b2");
            result.Name.ShouldBe("6dfb2e39a06c448d89acb0d410d1147eed7d62");
            result.Description.ShouldBe("712a2e4aaa1748648af183126dc0cd291b8c280ea77a44e9a99fb9eb83305feb");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _languageIsoNameLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _languageIsoNameLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}