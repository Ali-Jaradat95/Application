using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.ApiRequestResponseLogs
{
    public class ApiRequestResponseLogsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IApiRequestResponseLogsAppService _apiRequestResponseLogsAppService;
        private readonly IRepository<ApiRequestResponseLog, int> _apiRequestResponseLogRepository;

        public ApiRequestResponseLogsAppServiceTests()
        {
            _apiRequestResponseLogsAppService = GetRequiredService<IApiRequestResponseLogsAppService>();
            _apiRequestResponseLogRepository = GetRequiredService<IRepository<ApiRequestResponseLog, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _apiRequestResponseLogsAppService.GetListAsync(new GetApiRequestResponseLogsInput());

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
            var result = await _apiRequestResponseLogsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ApiRequestResponseLogCreateDto
            {
                RequestUrl = "f9c8387702b146d69ba0ef1b21ac57a79c65af2a9e4043eb80ebf2c5cc37a006eb4bdcf920664a9a966e3712b843",
                RequestMethod = "e97e594bcec740a4a29a9fb282",
                RequestHeaders = "a21a618867bc41ec8dd508fe317c044332ebf2db60064aa49a46e41c8594716950941b2719e",
                RequestBody = "6942f0a00362471a96dbf",
                ResponseBody = "5cd83117616a4d18a5f6ef64771808d32ea263558dfc40c1b1aeafa6b56d130",
                ResponseStatusCode = 1743567159,
                ResponseHeaders = "8d6a1746e21a486aa47e7fbd78583",
                DurationMs = 957176222,
                CreatedAt = new DateTime(2020, 4, 1),
                CorrelationId = "f6cb470110444a21a83fc6b8a1a0aafadcbf23f0b12546048f0c74bd357",
                IpAddress = "bfa5d9cb688042679b6d09a76cba8e69acaceb9fa91642e687f60deb211e14d28acebaf2d94541bc",
                UserId = "fb99d1aebaa94b1bbf95c94ad384642523e9ea",
                ErrorDetails = "1f4baca0b6ae42589a536d90b3062",
                IsSuccessful = true,
                SourceSystem = "61e912089a6f4297a4b5c20a9f98b145c1c4112fa34a4401abbcef736415c3c58cb2"
            };

            // Act
            var serviceResult = await _apiRequestResponseLogsAppService.CreateAsync(input);

            // Assert
            var result = await _apiRequestResponseLogRepository.FindAsync(c => c.RequestUrl == serviceResult.RequestUrl);

            result.ShouldNotBe(null);
            result.RequestUrl.ShouldBe("f9c8387702b146d69ba0ef1b21ac57a79c65af2a9e4043eb80ebf2c5cc37a006eb4bdcf920664a9a966e3712b843");
            result.RequestMethod.ShouldBe("e97e594bcec740a4a29a9fb282");
            result.RequestHeaders.ShouldBe("a21a618867bc41ec8dd508fe317c044332ebf2db60064aa49a46e41c8594716950941b2719e");
            result.RequestBody.ShouldBe("6942f0a00362471a96dbf");
            result.ResponseBody.ShouldBe("5cd83117616a4d18a5f6ef64771808d32ea263558dfc40c1b1aeafa6b56d130");
            result.ResponseStatusCode.ShouldBe(1743567159);
            result.ResponseHeaders.ShouldBe("8d6a1746e21a486aa47e7fbd78583");
            result.DurationMs.ShouldBe(957176222);
            result.CreatedAt.ShouldBe(new DateTime(2020, 4, 1));
            result.CorrelationId.ShouldBe("f6cb470110444a21a83fc6b8a1a0aafadcbf23f0b12546048f0c74bd357");
            result.IpAddress.ShouldBe("bfa5d9cb688042679b6d09a76cba8e69acaceb9fa91642e687f60deb211e14d28acebaf2d94541bc");
            result.UserId.ShouldBe("fb99d1aebaa94b1bbf95c94ad384642523e9ea");
            result.ErrorDetails.ShouldBe("1f4baca0b6ae42589a536d90b3062");
            result.IsSuccessful.ShouldBe(true);
            result.SourceSystem.ShouldBe("61e912089a6f4297a4b5c20a9f98b145c1c4112fa34a4401abbcef736415c3c58cb2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ApiRequestResponseLogUpdateDto()
            {
                RequestUrl = "021fb4d9399344089",
                RequestMethod = "a10e7b4b48a948bca7e47b85cfc79eb0e3ee700b306",
                RequestHeaders = "407c48c04e4f41a9a8c8c4bddeae2e6e06ed496788c444a9add48ec58998f7655a8c5f4430bb4014b7016659",
                RequestBody = "55b67c4b",
                ResponseBody = "8b573a479d9d43498020eaa70e25ff6693c1d66c54a94e9eba05ce7be9fe341b6c8bd92d23c3455aa6a8f9514834d",
                ResponseStatusCode = 1059590699,
                ResponseHeaders = "08aa2a72f8324287b1f3c2235d816877f222bd99084e4",
                DurationMs = 1926970797,
                CreatedAt = new DateTime(2000, 5, 17),
                CorrelationId = "b5958d84ad8145",
                IpAddress = "ebff7ae9e76a433b83900723093e00",
                UserId = "a0ba12d7b",
                ErrorDetails = "6138baf9c91f405bb441",
                IsSuccessful = true,
                SourceSystem = "b27b5cf8f08c4f97b482ef566a1b914b47b4ff9b1fe240c48e405f5265a77cb27d0470d0f67347f39a686ff6abe2742fb9"
            };

            // Act
            var serviceResult = await _apiRequestResponseLogsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _apiRequestResponseLogRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.RequestUrl.ShouldBe("021fb4d9399344089");
            result.RequestMethod.ShouldBe("a10e7b4b48a948bca7e47b85cfc79eb0e3ee700b306");
            result.RequestHeaders.ShouldBe("407c48c04e4f41a9a8c8c4bddeae2e6e06ed496788c444a9add48ec58998f7655a8c5f4430bb4014b7016659");
            result.RequestBody.ShouldBe("55b67c4b");
            result.ResponseBody.ShouldBe("8b573a479d9d43498020eaa70e25ff6693c1d66c54a94e9eba05ce7be9fe341b6c8bd92d23c3455aa6a8f9514834d");
            result.ResponseStatusCode.ShouldBe(1059590699);
            result.ResponseHeaders.ShouldBe("08aa2a72f8324287b1f3c2235d816877f222bd99084e4");
            result.DurationMs.ShouldBe(1926970797);
            result.CreatedAt.ShouldBe(new DateTime(2000, 5, 17));
            result.CorrelationId.ShouldBe("b5958d84ad8145");
            result.IpAddress.ShouldBe("ebff7ae9e76a433b83900723093e00");
            result.UserId.ShouldBe("a0ba12d7b");
            result.ErrorDetails.ShouldBe("6138baf9c91f405bb441");
            result.IsSuccessful.ShouldBe(true);
            result.SourceSystem.ShouldBe("b27b5cf8f08c4f97b482ef566a1b914b47b4ff9b1fe240c48e405f5265a77cb27d0470d0f67347f39a686ff6abe2742fb9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _apiRequestResponseLogsAppService.DeleteAsync(1);

            // Assert
            var result = await _apiRequestResponseLogRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}