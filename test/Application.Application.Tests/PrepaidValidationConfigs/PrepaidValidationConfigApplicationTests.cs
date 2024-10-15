using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.PrepaidValidationConfigs
{
    public class PrepaidValidationConfigsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IPrepaidValidationConfigsAppService _prepaidValidationConfigsAppService;
        private readonly IRepository<PrepaidValidationConfig, int> _prepaidValidationConfigRepository;

        public PrepaidValidationConfigsAppServiceTests()
        {
            _prepaidValidationConfigsAppService = GetRequiredService<IPrepaidValidationConfigsAppService>();
            _prepaidValidationConfigRepository = GetRequiredService<IRepository<PrepaidValidationConfig, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _prepaidValidationConfigsAppService.GetListAsync(new GetPrepaidValidationConfigsInput());

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
            var result = await _prepaidValidationConfigsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PrepaidValidationConfigCreateDto
            {
                ServiceType = "8acef76ad64d4667b884279ce17ef215c4cd850fbae148c19c197ca7cd9a6aa7c6f74066500",
                ChannelCode = "cf8323e52130436db9fccbe06d02368fa442df89d94845b6947",
                BillingName = "d115b3d3224d4f22a133dbf43fbf2e1e87e85050af2446a2be089f0899ea6c69ef1904f44f234bc9a90e4d",
                AliasBillingName = "d57c8a133e9845189e83cd0977e355870259ca83e6ac47779faa5f74947ded028209c51b22ee42b7bda9366cf26be",
                IsTesting = true,
                EndpointUrl = "4436252bdb654ecb935bfdd"
            };

            // Act
            var serviceResult = await _prepaidValidationConfigsAppService.CreateAsync(input);

            // Assert
            var result = await _prepaidValidationConfigRepository.FindAsync(c => c.ServiceType == serviceResult.ServiceType);

            result.ShouldNotBe(null);
            result.ServiceType.ShouldBe("8acef76ad64d4667b884279ce17ef215c4cd850fbae148c19c197ca7cd9a6aa7c6f74066500");
            result.ChannelCode.ShouldBe("cf8323e52130436db9fccbe06d02368fa442df89d94845b6947");
            result.BillingName.ShouldBe("d115b3d3224d4f22a133dbf43fbf2e1e87e85050af2446a2be089f0899ea6c69ef1904f44f234bc9a90e4d");
            result.AliasBillingName.ShouldBe("d57c8a133e9845189e83cd0977e355870259ca83e6ac47779faa5f74947ded028209c51b22ee42b7bda9366cf26be");
            result.IsTesting.ShouldBe(true);
            result.EndpointUrl.ShouldBe("4436252bdb654ecb935bfdd");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PrepaidValidationConfigUpdateDto()
            {
                ServiceType = "e0ee4e0e662243f993",
                ChannelCode = "36ff07a5c4424d8291a9a84c1bfbba6d48a857acd1d34e6ba4c1e9430ce7bbbf6b925735ace949abbd02",
                BillingName = "bc567aa1c4dd46efaaeeeae70494f7c4ccb1300c56044b97b193ce91c21a3a3806c",
                AliasBillingName = "2349ae75dbad42678c9b11c4eb08305e9f986",
                IsTesting = true,
                EndpointUrl = "e2161a9f26f14caa87b31fdb91ddb3f22b7135c43105426abcf8e12a26247f6961a78505103b4a4592390d"
            };

            // Act
            var serviceResult = await _prepaidValidationConfigsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _prepaidValidationConfigRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ServiceType.ShouldBe("e0ee4e0e662243f993");
            result.ChannelCode.ShouldBe("36ff07a5c4424d8291a9a84c1bfbba6d48a857acd1d34e6ba4c1e9430ce7bbbf6b925735ace949abbd02");
            result.BillingName.ShouldBe("bc567aa1c4dd46efaaeeeae70494f7c4ccb1300c56044b97b193ce91c21a3a3806c");
            result.AliasBillingName.ShouldBe("2349ae75dbad42678c9b11c4eb08305e9f986");
            result.IsTesting.ShouldBe(true);
            result.EndpointUrl.ShouldBe("e2161a9f26f14caa87b31fdb91ddb3f22b7135c43105426abcf8e12a26247f6961a78505103b4a4592390d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _prepaidValidationConfigsAppService.DeleteAsync(1);

            // Assert
            var result = await _prepaidValidationConfigRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}