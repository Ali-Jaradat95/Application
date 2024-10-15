using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.BillingStatusLookups
{
    public class BillingStatusLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IBillingStatusLookupsAppService _billingStatusLookupsAppService;
        private readonly IRepository<BillingStatusLookup, int> _billingStatusLookupRepository;

        public BillingStatusLookupsAppServiceTests()
        {
            _billingStatusLookupsAppService = GetRequiredService<IBillingStatusLookupsAppService>();
            _billingStatusLookupRepository = GetRequiredService<IRepository<BillingStatusLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _billingStatusLookupsAppService.GetListAsync(new GetBillingStatusLookupsInput());

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
            var result = await _billingStatusLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BillingStatusLookupCreateDto
            {
                Code = "b9ef953ab32d47bda83824c14991f39c7b232dfdd4a54888aa841ca407905c9a",
                Name = "9f26d443199c485898d9fa2b0bd0a6e768ec8b8",
                Description = "abf7dd3ca23140e98a068d955f8f175c6"
            };

            // Act
            var serviceResult = await _billingStatusLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _billingStatusLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("b9ef953ab32d47bda83824c14991f39c7b232dfdd4a54888aa841ca407905c9a");
            result.Name.ShouldBe("9f26d443199c485898d9fa2b0bd0a6e768ec8b8");
            result.Description.ShouldBe("abf7dd3ca23140e98a068d955f8f175c6");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BillingStatusLookupUpdateDto()
            {
                Code = "de19c290b3814334912c32572863f96f9a069dbe138d4465b585cc586d2dcc88961bed4151b",
                Name = "a377053c37f140a2a8edfb376bb56db7055518aa364f442eb315dac0717e9d561f0e45320",
                Description = "cfd2269202b54e96ad08466687c8d901c94747ac64194871b4012b7b6a15945bed167e94"
            };

            // Act
            var serviceResult = await _billingStatusLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _billingStatusLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("de19c290b3814334912c32572863f96f9a069dbe138d4465b585cc586d2dcc88961bed4151b");
            result.Name.ShouldBe("a377053c37f140a2a8edfb376bb56db7055518aa364f442eb315dac0717e9d561f0e45320");
            result.Description.ShouldBe("cfd2269202b54e96ad08466687c8d901c94747ac64194871b4012b7b6a15945bed167e94");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _billingStatusLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _billingStatusLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}