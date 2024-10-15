using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.MessageEncodingLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.MessageEncodingLookups
{
    public class MessageEncodingLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IMessageEncodingLookupRepository _messageEncodingLookupRepository;

        public MessageEncodingLookupRepositoryTests()
        {
            _messageEncodingLookupRepository = GetRequiredService<IMessageEncodingLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _messageEncodingLookupRepository.GetListAsync(
                    code: "82e3004a13f94f5fb380909db3c495e9ccb920",
                    name: "4d84939f112d428893ee9e665c48b05bafadccbaccb74c6b9a92e1bfa499b7adbc73fdd66ec642b5",
                    description: "a76562966b49444f9f0d1412aafdfce5565d0d34b9574fcba4dfc8e5a16db2d89b5ca6e"
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
                var result = await _messageEncodingLookupRepository.GetCountAsync(
                    code: "69ee83",
                    name: "3babb639fbbf46d7b7",
                    description: "7901e1af2e34455881fc900340cd30d0efaddf4f38fa4933b77d91a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}