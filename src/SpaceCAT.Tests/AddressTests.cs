using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace SpaceCAT.Tests;

public partial class SpaceCATClientTests : TestBase
{
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getaddressbalances_matches_expected_schema()
    {
        // arrange
        var address = "xch1y6krqgs2cjz6mjgz5wy4dd5zqghm3a5pgueccjtudchn2xzcajtsnyzvgy"; //chia network
    
        // act
        var (_, httpResponse) = await Client.GetAddressBalance(address);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var balanceobj = JObject.Parse(job.GetValue("data").ToString());
        var balance = balanceobj.Value<JObject>("balance");
        var received = balanceobj.Value<JObject>("received");
        var sent = balanceobj.Value<JObject>("sent");
        
        // assert
        balanceobj.Should().HaveCount(3);
        balance.Should().HaveElement("mojo");
        balance.Should().HaveElement("xch");
        balance.Should().HaveElement("usd");
        balance.Should().HaveCount(3);
        
        //sender
        received.Should().HaveElement("mojo");
        received.Should().HaveElement("xch");
        received.Should().HaveElement("usd");
        received.Should().HaveCount(3);
        
        //receiver
        sent.Should().HaveElement("mojo");
        sent.Should().HaveElement("xch");
        sent.Should().HaveElement("usd");
        sent.Should().HaveCount(3);
    }
    
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getaddressissuedcats_matches_expected_schema()
    {
        // arrange
        var address = "xch1murr8nnzd45rl5x63ykc3yw6v00qck5rk5z2gxxpypgeuw6tvjususw8fp"; //dbx issuer
    
        // act
        var (_, httpResponse) = await Client.GetAddressIssuedCATS(address);
        
        // Asssert
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var cats = JArray.Parse(job.GetValue("cats").ToString());
        var cat = cats?.First();
        var social = cat.Value<JObject>("social");
        
        cat.Should().HaveElement("id");
        cat.Should().HaveElement("symbol");
        cat.Should().HaveElement("name");
        cat.Should().HaveElement("description");
        cat.Should().HaveElement("type");
        cat.Should().HaveElement("holders");
        cat.Should().HaveElement("issuance_type");
        cat.Should().HaveElement("total_supply");
        cat.Should().HaveElement("created_time");
        cat.Should().HaveElement("price_usd");
        cat.Should().HaveElement("price_xch");
        cat.Should().HaveElement("social");
        cat.Should().HaveElement("tags");
        cat.Should().HaveElement("multiplier");
        cat.Should().HaveElement("transactions");
        cat.Should().HaveElement("preview_url");
        cat.Should().HaveCount(16);
    
        //social
        social.Should().HaveElement("reddit");
        social.Should().HaveElement("discord");
        social.Should().HaveElement("twitter");
        social.Should().HaveElement("website");
        social.Should().HaveElement("whitepaper");
        social.Should().HaveElement("verified");
        social.Should().HaveCount(6);
    }
}