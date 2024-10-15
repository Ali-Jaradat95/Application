using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.OperationTypeLookups;
using Application.EntityFrameworkCore;
using Xunit;

namespace Application.OperationTypeLookups
{
    public class OperationTypeLookupRepositoryTests : ApplicationEntityFrameworkCoreTestBase
    {
        private readonly IOperationTypeLookupRepository _operationTypeLookupRepository;

        public OperationTypeLookupRepositoryTests()
        {
            _operationTypeLookupRepository = GetRequiredService<IOperationTypeLookupRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _operationTypeLookupRepository.GetListAsync(
                    code: "7f998845b63f4480b4e5f611e68",
                    name: "2e684eb5da124faeb5087267928f6d669a7a3a8e4603448ebf280d6df58e60d2",
                    description: "8e3d3962edc64062ba8cf2d24c74d78ff62"
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
                var result = await _operationTypeLookupRepository.GetCountAsync(
                    code: "323a069a040f4b18b069cceb192a8a0e",
                    name: "b9b584890d5741bfb53c8c581e5ab9f0fcb3900edd994837bf5961d7cb4a609aa467cca7b3e1430ebf73412e8085d6b8f",
                    description: "02637ba1df2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}