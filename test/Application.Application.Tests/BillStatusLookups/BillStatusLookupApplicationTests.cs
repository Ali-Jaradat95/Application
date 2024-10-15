using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.BillStatusLookups
{
    public class BillStatusLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IBillStatusLookupsAppService _billStatusLookupsAppService;
        private readonly IRepository<BillStatusLookup, int> _billStatusLookupRepository;

        public BillStatusLookupsAppServiceTests()
        {
            _billStatusLookupsAppService = GetRequiredService<IBillStatusLookupsAppService>();
            _billStatusLookupRepository = GetRequiredService<IRepository<BillStatusLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _billStatusLookupsAppService.GetListAsync(new GetBillStatusLookupsInput());

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
            var result = await _billStatusLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BillStatusLookupCreateDto
            {
                Code = "fed1786772f84636a53ab3e2fef68893f14be9fb27694226bf01e55e5e9e543a5e23",
                Name = "6cd0f6cdc07745e79f5fb28b6b608ec5a88a51e509464d0daeea92ea938ad44bdec505b5df024a8cb9622c",
                Description = "921eba38f11d4cfdab31048f0fea8f2b2ae474c1e30e4cc5b5284195a77bdaf1d7a2eeb238864dfbba7e540b8d45bfdf7"
            };

            // Act
            var serviceResult = await _billStatusLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _billStatusLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("fed1786772f84636a53ab3e2fef68893f14be9fb27694226bf01e55e5e9e543a5e23");
            result.Name.ShouldBe("6cd0f6cdc07745e79f5fb28b6b608ec5a88a51e509464d0daeea92ea938ad44bdec505b5df024a8cb9622c");
            result.Description.ShouldBe("921eba38f11d4cfdab31048f0fea8f2b2ae474c1e30e4cc5b5284195a77bdaf1d7a2eeb238864dfbba7e540b8d45bfdf7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BillStatusLookupUpdateDto()
            {
                Code = "632b44da8dac467eb452cd2b07974e202272d08dabb6",
                Name = "0791550b6ba844519e1",
                Description = "fbf0b83af77e44738dd1b4a2e991d2f5e120b08fe22c4b6bbc51cf1de91035b4105bb33c7e99462"
            };

            // Act
            var serviceResult = await _billStatusLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _billStatusLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("632b44da8dac467eb452cd2b07974e202272d08dabb6");
            result.Name.ShouldBe("0791550b6ba844519e1");
            result.Description.ShouldBe("fbf0b83af77e44738dd1b4a2e991d2f5e120b08fe22c4b6bbc51cf1de91035b4105bb33c7e99462");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _billStatusLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _billStatusLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}