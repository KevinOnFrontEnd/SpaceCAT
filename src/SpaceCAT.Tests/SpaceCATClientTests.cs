using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace SpaceCAT.Tests;

public class SpaceCATClientTests : TestBase
{
    public SpaceCATClientTests(SpaceCATTestFixture fixture) : base(fixture)
    {
    }
    
    [Fact()]
    [Trait("Category","Schema")]
    public async Task cat_matches_expected_schema()
    {
        // arrange
        var assetId = "db1a9020d48d9d4ad22631b66ab4b9ebd3637ef7758ad38881348c5d24c38f20"; //Dexie bucks (DBX)

        // act
        var (_, httpResponse) = await Client.GetCAT(assetId);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var cats = JArray.Parse(job.GetValue("cat").ToString());
        var cat = JObject.Parse(cats.FirstOrDefault().ToString());
        
        // assert
        cat.Should().HaveElement("asset_id");
        cat.Should().HaveElement("asset_name");
        cat.Should().HaveElement("symbol");
        cat.Should().HaveElement("price_usd");
        cat.Should().HaveElement("price_xch");
        cat.Should().HaveElement("issued_time");
        cat.Should().HaveElement("updated");
        cat.Should().HaveElement("holders");
        cat.Should().HaveElement("lisp");
        cat.Should().HaveElement("clvm");
        cat.Should().HaveElement("description");
        cat.Should().HaveElement("tags");
        cat.Should().HaveElement("total_supply");
        cat.Should().HaveElement("txns_count");
        cat.Should().HaveElement("txns_amount");
        cat.Should().HaveElement("logo");
        //cat.Should().HaveCount(16);
    }
}