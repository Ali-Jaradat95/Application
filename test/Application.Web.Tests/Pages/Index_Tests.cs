using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Application.Pages;

public class Index_Tests : ApplicationWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
