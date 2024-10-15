using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PaymentMethodLookups
{
    public class PaymentMethodLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPaymentMethodLookupsAppService _paymentMethodLookupsAppService;
        private readonly IRepository<PaymentMethodLookup, int> _paymentMethodLookupRepository;

        public PaymentMethodLookupsAppServiceTests()
        {
            _paymentMethodLookupsAppService = GetRequiredService<IPaymentMethodLookupsAppService>();
            _paymentMethodLookupRepository = GetRequiredService<IRepository<PaymentMethodLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _paymentMethodLookupsAppService.GetListAsync(new GetPaymentMethodLookupsInput());

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
            var result = await _paymentMethodLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PaymentMethodLookupCreateDto
            {
                Code = "9ed6b405385e4ae9a7d266f66a0f52657698d29095ad44498f62aeee8da660c1f19c3f031d794f0b8",
                Name = "3576954a02fe",
                Description = "25b4ed0dba614d28ab2e1ba0ed69ba88904d9aa7abcc4a7885d1985a85277"
            };

            // Act
            var serviceResult = await _paymentMethodLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _paymentMethodLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("9ed6b405385e4ae9a7d266f66a0f52657698d29095ad44498f62aeee8da660c1f19c3f031d794f0b8");
            result.Name.ShouldBe("3576954a02fe");
            result.Description.ShouldBe("25b4ed0dba614d28ab2e1ba0ed69ba88904d9aa7abcc4a7885d1985a85277");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PaymentMethodLookupUpdateDto()
            {
                Code = "a1eae5c9008c4a93a0690e495715fa08f37",
                Name = "c30d687099394ab8846e38",
                Description = "1b03597ca2e64f22a4218ea80790da3bf5bf798a7e63462994900e5eca370b6f236fc4ee92514ad28"
            };

            // Act
            var serviceResult = await _paymentMethodLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _paymentMethodLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("a1eae5c9008c4a93a0690e495715fa08f37");
            result.Name.ShouldBe("c30d687099394ab8846e38");
            result.Description.ShouldBe("1b03597ca2e64f22a4218ea80790da3bf5bf798a7e63462994900e5eca370b6f236fc4ee92514ad28");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _paymentMethodLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _paymentMethodLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}