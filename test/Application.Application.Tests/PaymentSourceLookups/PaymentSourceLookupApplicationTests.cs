using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PaymentSourceLookups
{
    public class PaymentSourceLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPaymentSourceLookupsAppService _paymentSourceLookupsAppService;
        private readonly IRepository<PaymentSourceLookup, int> _paymentSourceLookupRepository;

        public PaymentSourceLookupsAppServiceTests()
        {
            _paymentSourceLookupsAppService = GetRequiredService<IPaymentSourceLookupsAppService>();
            _paymentSourceLookupRepository = GetRequiredService<IRepository<PaymentSourceLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _paymentSourceLookupsAppService.GetListAsync(new GetPaymentSourceLookupsInput());

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
            var result = await _paymentSourceLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PaymentSourceLookupCreateDto
            {
                Code = "815ee7c2409946d5b8130f8523f6cde0176bca6b831343fb8410eec504c3008",
                Name = "092b6bf2a528422394f117bd24c",
                Description = "43c8b94d61464d1db1535e6826da235cea583a58bb1d4029b0be5abdd24"
            };

            // Act
            var serviceResult = await _paymentSourceLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _paymentSourceLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("815ee7c2409946d5b8130f8523f6cde0176bca6b831343fb8410eec504c3008");
            result.Name.ShouldBe("092b6bf2a528422394f117bd24c");
            result.Description.ShouldBe("43c8b94d61464d1db1535e6826da235cea583a58bb1d4029b0be5abdd24");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PaymentSourceLookupUpdateDto()
            {
                Code = "35db98c5821a4fac8bd4cc67673c0d994acade8493ee4851a7f",
                Name = "f8a33701411c4cfa9e9fb56cc49bbc1128c8a7f127",
                Description = "73b50354e1da408d87a7c993e4cd19a2ea7cb09506d942d38c7cc5b6dd95d90a249f390e033a475e9e3d8"
            };

            // Act
            var serviceResult = await _paymentSourceLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _paymentSourceLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("35db98c5821a4fac8bd4cc67673c0d994acade8493ee4851a7f");
            result.Name.ShouldBe("f8a33701411c4cfa9e9fb56cc49bbc1128c8a7f127");
            result.Description.ShouldBe("73b50354e1da408d87a7c993e4cd19a2ea7cb09506d942d38c7cc5b6dd95d90a249f390e033a475e9e3d8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _paymentSourceLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _paymentSourceLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}