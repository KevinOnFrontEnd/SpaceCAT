using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace SpaceCAT.Tests;

public partial class SpaceCATClientTests : TestBase
{
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getdidinfo_matches_expected_schema()
    {
        // arrange
        var did = "did:chia:1cg78ydwn9dpqdxh84xdqts4kj8fve2y4vsafu93e79d2uakaukuq6geqad";

        // act
        var (_, httpResponse) = await Client.GetDIDInfo(did);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var didinfo = JObject.Parse(job.GetValue("data").ToString());
        var didobj = JObject.Parse(didinfo.GetValue("did").ToString());
        
        // Assert
        didinfo.Should().HaveElement("did");
        didinfo.Should().HaveCount(1);
        didobj.Should().HaveElement("did");
        didobj. Should().HaveElement("did_hex");
        didobj.Should().HaveCount(2);
    }
}