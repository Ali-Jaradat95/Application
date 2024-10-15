using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PaymentStatusLookups
{
    public class PaymentStatusLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPaymentStatusLookupsAppService _paymentStatusLookupsAppService;
        private readonly IRepository<PaymentStatusLookup, int> _paymentStatusLookupRepository;

        public PaymentStatusLookupsAppServiceTests()
        {
            _paymentStatusLookupsAppService = GetRequiredService<IPaymentStatusLookupsAppService>();
            _paymentStatusLookupRepository = GetRequiredService<IRepository<PaymentStatusLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _paymentStatusLookupsAppService.GetListAsync(new GetPaymentStatusLookupsInput());

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
            var result = await _paymentStatusLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PaymentStatusLookupCreateDto
            {
                Code = "a75b3b14983b440686aa9686f30ae0de35b9ee56e574",
                Name = "cbcd8b23862f4ac7b54079cf2e8613638f60cb42e6a2421f8fc06ae49dff612cf6ffec7fa4f94f5bbe6d10ac158820b7",
                Description = "584dea921a5b4af4a3b51"
            };

            // Act
            var serviceResult = await _paymentStatusLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _paymentStatusLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("a75b3b14983b440686aa9686f30ae0de35b9ee56e574");
            result.Name.ShouldBe("cbcd8b23862f4ac7b54079cf2e8613638f60cb42e6a2421f8fc06ae49dff612cf6ffec7fa4f94f5bbe6d10ac158820b7");
            result.Description.ShouldBe("584dea921a5b4af4a3b51");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PaymentStatusLookupUpdateDto()
            {
                Code = "51c8d7ebb3634ff39ea22bebd2f216b44e0e91fd6f7f4dfea5c31af9c059903d014ef05",
                Name = "d4ce48c7355341729913267b9682a0b6cf6a5a8858af4f2fabaaea75ae395fb6d3f2982b20734",
                Description = "bc12efd8c9f045a1bf0f1560c70fef5e08ad859d7aa846"
            };

            // Act
            var serviceResult = await _paymentStatusLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _paymentStatusLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("51c8d7ebb3634ff39ea22bebd2f216b44e0e91fd6f7f4dfea5c31af9c059903d014ef05");
            result.Name.ShouldBe("d4ce48c7355341729913267b9682a0b6cf6a5a8858af4f2fabaaea75ae395fb6d3f2982b20734");
            result.Description.ShouldBe("bc12efd8c9f045a1bf0f1560c70fef5e08ad859d7aa846");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _paymentStatusLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _paymentStatusLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}