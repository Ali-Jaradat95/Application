using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.BillTypeLookups
{
    public class BillTypeLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IBillTypeLookupsAppService _billTypeLookupsAppService;
        private readonly IRepository<BillTypeLookup, int> _billTypeLookupRepository;

        public BillTypeLookupsAppServiceTests()
        {
            _billTypeLookupsAppService = GetRequiredService<IBillTypeLookupsAppService>();
            _billTypeLookupRepository = GetRequiredService<IRepository<BillTypeLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _billTypeLookupsAppService.GetListAsync(new GetBillTypeLookupsInput());

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
            var result = await _billTypeLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BillTypeLookupCreateDto
            {
                Code = "5f0f9b2eeab94eeea97303ae6edcd71",
                Name = "f1535352b12b4a2a97093546e6eb",
                Description = "42ae47f6fc0d4b84b642fbe0c7fa"
            };

            // Act
            var serviceResult = await _billTypeLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _billTypeLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("5f0f9b2eeab94eeea97303ae6edcd71");
            result.Name.ShouldBe("f1535352b12b4a2a97093546e6eb");
            result.Description.ShouldBe("42ae47f6fc0d4b84b642fbe0c7fa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BillTypeLookupUpdateDto()
            {
                Code = "2ac4c2a26064423aad4f04d5e4ec4620dae9fbd889954f6b98ec6d6c9666eaafa269f131",
                Name = "99476d8e112f45ffad41af7bf6af367925c19a8bf0ca4aeab046437f253d",
                Description = "9f4d4e8f688243a7"
            };

            // Act
            var serviceResult = await _billTypeLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _billTypeLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("2ac4c2a26064423aad4f04d5e4ec4620dae9fbd889954f6b98ec6d6c9666eaafa269f131");
            result.Name.ShouldBe("99476d8e112f45ffad41af7bf6af367925c19a8bf0ca4aeab046437f253d");
            result.Description.ShouldBe("9f4d4e8f688243a7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _billTypeLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _billTypeLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}