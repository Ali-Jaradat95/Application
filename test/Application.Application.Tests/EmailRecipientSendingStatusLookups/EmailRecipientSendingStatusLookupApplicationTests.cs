using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.EmailRecipientSendingStatusLookups
{
    public class EmailRecipientSendingStatusLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IEmailRecipientSendingStatusLookupsAppService _emailRecipientSendingStatusLookupsAppService;
        private readonly IRepository<EmailRecipientSendingStatusLookup, int> _emailRecipientSendingStatusLookupRepository;

        public EmailRecipientSendingStatusLookupsAppServiceTests()
        {
            _emailRecipientSendingStatusLookupsAppService = GetRequiredService<IEmailRecipientSendingStatusLookupsAppService>();
            _emailRecipientSendingStatusLookupRepository = GetRequiredService<IRepository<EmailRecipientSendingStatusLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _emailRecipientSendingStatusLookupsAppService.GetListAsync(new GetEmailRecipientSendingStatusLookupsInput());

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
            var result = await _emailRecipientSendingStatusLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new EmailRecipientSendingStatusLookupCreateDto
            {
                Code = "3f5832c6d3384ed09d4685",
                Name = "81ab093f86d14a9792bccd6d2b7f24ebdbc54d2",
                Description = "5454b1a9c6ab40269d895a9a219d83bbd86f574e0e25434081ed7011401eccc376fd835f5a5e4a66"
            };

            // Act
            var serviceResult = await _emailRecipientSendingStatusLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _emailRecipientSendingStatusLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("3f5832c6d3384ed09d4685");
            result.Name.ShouldBe("81ab093f86d14a9792bccd6d2b7f24ebdbc54d2");
            result.Description.ShouldBe("5454b1a9c6ab40269d895a9a219d83bbd86f574e0e25434081ed7011401eccc376fd835f5a5e4a66");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new EmailRecipientSendingStatusLookupUpdateDto()
            {
                Code = "48e8eeeaeb574369a0ec5ba6751aff1d30fd032b84a04f3cb4b5d1de6f5ebd467",
                Name = "358a7ecbfa374e2a",
                Description = "69f2864a9fbe4ff88e664478e22f76052f7c61f2c"
            };

            // Act
            var serviceResult = await _emailRecipientSendingStatusLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _emailRecipientSendingStatusLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("48e8eeeaeb574369a0ec5ba6751aff1d30fd032b84a04f3cb4b5d1de6f5ebd467");
            result.Name.ShouldBe("358a7ecbfa374e2a");
            result.Description.ShouldBe("69f2864a9fbe4ff88e664478e22f76052f7c61f2c");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _emailRecipientSendingStatusLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _emailRecipientSendingStatusLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}