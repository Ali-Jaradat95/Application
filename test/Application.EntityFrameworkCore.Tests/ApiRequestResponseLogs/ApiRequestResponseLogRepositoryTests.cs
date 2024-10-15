using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.ApiRequestResponseLogs;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.ApiRequestResponseLogs
{
    public class ApiRequestResponseLogRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IApiRequestResponseLogRepository _apiRequestResponseLogRepository;

        public ApiRequestResponseLogRepositoryTests()
        {
            _apiRequestResponseLogRepository = GetRequiredService<IApiRequestResponseLogRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _apiRequestResponseLogRepository.GetListAsync(
                    requestUrl: "fa307d8f30a14924bd273bc4e739f6a3b6de5578623742aa92c4d52e8c04bfff",
                    requestMethod: "994242d9ec7449b7be1a06be74c7018a551a6fa8eec24b02b6f10d6e",
                    requestHeaders: "4f67384e515f426882fb790de2e7f06eb2ae244aa1294fcea4f92dc492519b5eee7a3369a2f54c339f13f08951b52dcba",
                    requestBody: "dcfa8515d81b44179ad9ae836c0f58dc6295ffbdfa414a2fb15ed5289671b287ad24d6d38e894d6",
                    responseBody: "9d03c75c315c452985ee683d865af75ff",
                    responseHeaders: "558b9526a2f84903bebec2da832d5432af8a42071a6e421389eb",
                    correlationId: "07cb5c72a6754189a582867125b14ebb3e287302035a4527939f2ffc7a5de7d",
                    ipAddress: "eec16a89654941edabf88fbb",
                    userId: "7033b3131f2b433a96e0",
                    errorDetails: "87c717cdfebb41c6a1a8c3cf18f6f9ad23adee4964cb40a9a0c308b094422c1beca98916e8544e4",
                    isSuccessful: true,
                    sourceSystem: "e9d1cfbd1b3244a785946a4"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _apiRequestResponseLogRepository.GetCountAsync(
                    requestUrl: "4507d1c434f54c6ab67ac903de4fd77fb8876df5465141d6aa",
                    requestMethod: "b6db3a852c784262a280132e0244dc8cd42b4309ee434d9b8be229be04458676a5362",
                    requestHeaders: "9d1b6b121d0047c2b72f299",
                    requestBody: "e316033943dc40dc95a45bbf72ea375eac9482d1fc674fcc88c1e3bdad8f63ce5d25709ede3c4c08840",
                    responseBody: "60ab5a33851343c3a23b64bdcf566362e8f47bb2a6144b7093c0ef7a8b2e298ded13a898",
                    responseHeaders: "f292bb74342548e1abca6c6e52dc55b4327c4aa48b294f6ca4098668fb748bf0e8e3857a6d1746ccbeb",
                    correlationId: "5c35d3a47c694053",
                    ipAddress: "e4e4202af9b0474faa247136",
                    userId: "7e10d13080304f7ab88a2ef46800038c07cdb9f567b4436bb87ad02185e705828fc982ff1434",
                    errorDetails: "4008e340130a4126af5e7ad903bdee714",
                    isSuccessful: true,
                    sourceSystem: "3ef724ce5d1a4cfb955ecab8cbd629df30c9639703b747d891d9e1d488429f5f08fd74e0"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}