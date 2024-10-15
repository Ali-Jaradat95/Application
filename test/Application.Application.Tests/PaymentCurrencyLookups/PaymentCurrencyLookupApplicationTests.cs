using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PaymentCurrencyLookups
{
    public class PaymentCurrencyLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPaymentCurrencyLookupsAppService _paymentCurrencyLookupsAppService;
        private readonly IRepository<PaymentCurrencyLookup, int> _paymentCurrencyLookupRepository;

        public PaymentCurrencyLookupsAppServiceTests()
        {
            _paymentCurrencyLookupsAppService = GetRequiredService<IPaymentCurrencyLookupsAppService>();
            _paymentCurrencyLookupRepository = GetRequiredService<IRepository<PaymentCurrencyLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _paymentCurrencyLookupsAppService.GetListAsync(new GetPaymentCurrencyLookupsInput());

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
            var result = await _paymentCurrencyLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PaymentCurrencyLookupCreateDto
            {
                Code = "df6018b64b304f428bb96b16557",
                Name = "a1a24e58b4a5460cbbd6e87ee440b390be9593ff2cd",
                Description = "261e175bdb1e41ce9b7ee3697694b680b419c1d2c55a4e86a99cf68553653d26a5"
            };

            // Act
            var serviceResult = await _paymentCurrencyLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _paymentCurrencyLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("df6018b64b304f428bb96b16557");
            result.Name.ShouldBe("a1a24e58b4a5460cbbd6e87ee440b390be9593ff2cd");
            result.Description.ShouldBe("261e175bdb1e41ce9b7ee3697694b680b419c1d2c55a4e86a99cf68553653d26a5");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PaymentCurrencyLookupUpdateDto()
            {
                Code = "2e3824e20a1c474d88731c1735996410c5f64076ad5f46828856d31ffe82ce7bda2c04f269c74e298480433",
                Name = "8de9c07a6394468fb56ca45bda0cef0126e5ac2cc3a34f7eb5e612f88967c21da8b73776fa114",
                Description = "bd0e9df4d9de4962b4479254c45bf7f6"
            };

            // Act
            var serviceResult = await _paymentCurrencyLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _paymentCurrencyLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("2e3824e20a1c474d88731c1735996410c5f64076ad5f46828856d31ffe82ce7bda2c04f269c74e298480433");
            result.Name.ShouldBe("8de9c07a6394468fb56ca45bda0cef0126e5ac2cc3a34f7eb5e612f88967c21da8b73776fa114");
            result.Description.ShouldBe("bd0e9df4d9de4962b4479254c45bf7f6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _paymentCurrencyLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _paymentCurrencyLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}