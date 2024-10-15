using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PaymentTypeLookups
{
    public class PaymentTypeLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPaymentTypeLookupsAppService _paymentTypeLookupsAppService;
        private readonly IRepository<PaymentTypeLookup, int> _paymentTypeLookupRepository;

        public PaymentTypeLookupsAppServiceTests()
        {
            _paymentTypeLookupsAppService = GetRequiredService<IPaymentTypeLookupsAppService>();
            _paymentTypeLookupRepository = GetRequiredService<IRepository<PaymentTypeLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _paymentTypeLookupsAppService.GetListAsync(new GetPaymentTypeLookupsInput());

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
            var result = await _paymentTypeLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PaymentTypeLookupCreateDto
            {
                Code = "02ebcd002c42418d9d3bff0b606cfbfec2fdd1cc65af4cf481979474d6378796471e9798d5a443",
                Name = "51e3af31893543f0bfe97a2814488682ce137a8ec9634fac8235a8a43c30c2dd218cd895ad9c",
                Description = "ac8aea26772f4b58a0b4280f19d2ae1e09"
            };

            // Act
            var serviceResult = await _paymentTypeLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _paymentTypeLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("02ebcd002c42418d9d3bff0b606cfbfec2fdd1cc65af4cf481979474d6378796471e9798d5a443");
            result.Name.ShouldBe("51e3af31893543f0bfe97a2814488682ce137a8ec9634fac8235a8a43c30c2dd218cd895ad9c");
            result.Description.ShouldBe("ac8aea26772f4b58a0b4280f19d2ae1e09");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PaymentTypeLookupUpdateDto()
            {
                Code = "0ae6c7c505a6437290d75aa77bf0218210e03521e62745da90d37bbe0f7",
                Name = "1df2b718a98a4906968a837ddc5ba7328b34bbc1c41d43a9ab3295cfb8b8ed0956a97a2b6f",
                Description = "8ef71492c697465b918221d35a979b332e648c95c58d42c19ca44fe05174ddf244b22d"
            };

            // Act
            var serviceResult = await _paymentTypeLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _paymentTypeLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("0ae6c7c505a6437290d75aa77bf0218210e03521e62745da90d37bbe0f7");
            result.Name.ShouldBe("1df2b718a98a4906968a837ddc5ba7328b34bbc1c41d43a9ab3295cfb8b8ed0956a97a2b6f");
            result.Description.ShouldBe("8ef71492c697465b918221d35a979b332e648c95c58d42c19ca44fe05174ddf244b22d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _paymentTypeLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _paymentTypeLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}