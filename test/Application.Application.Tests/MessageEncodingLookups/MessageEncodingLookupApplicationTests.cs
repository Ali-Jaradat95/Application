using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.MessageEncodingLookups
{
    public class MessageEncodingLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IMessageEncodingLookupsAppService _messageEncodingLookupsAppService;
        private readonly IRepository<MessageEncodingLookup, int> _messageEncodingLookupRepository;

        public MessageEncodingLookupsAppServiceTests()
        {
            _messageEncodingLookupsAppService = GetRequiredService<IMessageEncodingLookupsAppService>();
            _messageEncodingLookupRepository = GetRequiredService<IRepository<MessageEncodingLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _messageEncodingLookupsAppService.GetListAsync(new GetMessageEncodingLookupsInput());

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
            var result = await _messageEncodingLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MessageEncodingLookupCreateDto
            {
                Code = "da13d651af1a402ab147948029d84d07826612c520fd4dfaac001efce1695b86f1d9511156a548e8877d47",
                Name = "30013ee26bb0404cb098878ce80ac823ee56de4",
                Description = "d92982479f5747a88a484a4fa9b02de26734dda5c96c4b0a910e1366dbbab55"
            };

            // Act
            var serviceResult = await _messageEncodingLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _messageEncodingLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("da13d651af1a402ab147948029d84d07826612c520fd4dfaac001efce1695b86f1d9511156a548e8877d47");
            result.Name.ShouldBe("30013ee26bb0404cb098878ce80ac823ee56de4");
            result.Description.ShouldBe("d92982479f5747a88a484a4fa9b02de26734dda5c96c4b0a910e1366dbbab55");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MessageEncodingLookupUpdateDto()
            {
                Code = "9e5a1d6e0ba",
                Name = "b9a0af1dd850481580723e6f00052251ff1099",
                Description = "05b15c6eca2841aabf18e6c750307de58220ffce"
            };

            // Act
            var serviceResult = await _messageEncodingLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _messageEncodingLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("9e5a1d6e0ba");
            result.Name.ShouldBe("b9a0af1dd850481580723e6f00052251ff1099");
            result.Description.ShouldBe("05b15c6eca2841aabf18e6c750307de58220ffce");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _messageEncodingLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _messageEncodingLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}