using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PrepaidCategoryLookups
{
    public class PrepaidCategoryLookupsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPrepaidCategoryLookupsAppService _prepaidCategoryLookupsAppService;
        private readonly IRepository<PrepaidCategoryLookup, int> _prepaidCategoryLookupRepository;

        public PrepaidCategoryLookupsAppServiceTests()
        {
            _prepaidCategoryLookupsAppService = GetRequiredService<IPrepaidCategoryLookupsAppService>();
            _prepaidCategoryLookupRepository = GetRequiredService<IRepository<PrepaidCategoryLookup, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _prepaidCategoryLookupsAppService.GetListAsync(new GetPrepaidCategoryLookupsInput());

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
            var result = await _prepaidCategoryLookupsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PrepaidCategoryLookupCreateDto
            {
                Code = "15d831a7d2c54e1fb9eb39b1717ab49a31498c",
                Name = "cd703cb76031",
                Description = "cbc7c3135f0446f5841dd6af3f123c391d46404bf38e48438993dda22383b1c741ea698"
            };

            // Act
            var serviceResult = await _prepaidCategoryLookupsAppService.CreateAsync(input);

            // Assert
            var result = await _prepaidCategoryLookupRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("15d831a7d2c54e1fb9eb39b1717ab49a31498c");
            result.Name.ShouldBe("cd703cb76031");
            result.Description.ShouldBe("cbc7c3135f0446f5841dd6af3f123c391d46404bf38e48438993dda22383b1c741ea698");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PrepaidCategoryLookupUpdateDto()
            {
                Code = "2f6e41b502f3449bab6cffc4a83268114a8d9b2b9eae44e58f9d4a6736cf4fcfd43f6267ada840",
                Name = "b5b84a953fcf4036add8e00fa0001dfd9cda8b6",
                Description = "70c56f096c6f474994a911178be90940f136033a695646a786a4aad4c5"
            };

            // Act
            var serviceResult = await _prepaidCategoryLookupsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _prepaidCategoryLookupRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("2f6e41b502f3449bab6cffc4a83268114a8d9b2b9eae44e58f9d4a6736cf4fcfd43f6267ada840");
            result.Name.ShouldBe("b5b84a953fcf4036add8e00fa0001dfd9cda8b6");
            result.Description.ShouldBe("70c56f096c6f474994a911178be90940f136033a695646a786a4aad4c5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _prepaidCategoryLookupsAppService.DeleteAsync(1);

            // Assert
            var result = await _prepaidCategoryLookupRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}