using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace SpaceCAT.Tests;

public partial class SpaceCATClientTests : TestBase
{
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getprice_matches_expected_schema()
    {
        // arrange

        // act
        var (_, httpResponse) = await Client.GetPrice();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var priceobj = JObject.Parse(job.GetValue("data").ToString());
        var price = priceobj.GetValue("price");
        
        // assert
        priceobj.Should().HaveCount(2);
        priceobj.Should().HaveElement("price");
        priceobj.Should().HaveElement("timestamp");
    }
    
    [Fact]
    [Trait("Category", "Schema")]
    public async Task gettotalsupply_matches_expected_schema()
    {
        // arrange

        // act
        var (_, httpResponse) = await Client.GetTotalSupply();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var priceobj = JObject.Parse(job.GetValue("data").ToString());

        // assert
        priceobj.Should().HaveCount(1);
        priceobj.Should().HaveElement("Total_Supply");
    }
}