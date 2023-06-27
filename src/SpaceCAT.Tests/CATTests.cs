using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace SpaceCAT.Tests;

public partial class SpaceCATClientTests : TestBase
{
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getcat_matches_expected_schema()
    {
        // arrange
        var assetId = "db1a9020d48d9d4ad22631b66ab4b9ebd3637ef7758ad38881348c5d24c38f20"; //Dexie bucks (DBX)

        // act
        var (catobj, httpResponse) = await Client.GetCAT(assetId);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var cat = JObject.Parse(job.GetValue("data").ToString());
        var social = JObject.Parse(cat.GetValue("social").ToString());
        var issuedcoins = JArray.Parse(cat.GetValue("issued_coins").ToString());
        var issuedcoin = issuedcoins.FirstOrDefault();
        
        // assert
        cat.Should().HaveElement("id");
        cat.Should().HaveElement("name");
        cat.Should().HaveElement("symbol");
        cat.Should().HaveElement("type");
        cat.Should().HaveElement("holders");
        cat.Should().HaveElement("issuance_type");
        cat.Should().HaveElement("issued_coins");
        cat.Should().HaveElement("total_supply");
        cat.Should().HaveElement("created_time");
        cat.Should().HaveElement("price_usd");
        cat.Should().HaveElement("price_xch");
        cat.Should().HaveElement("social");
        cat.Should().HaveElement("tags");
        cat.Should().HaveElement("transactions");
        cat.Should().HaveElement("preview_url");
        cat.Should().HaveElement("multiplier");
        cat.Should().HaveCount(17);
    
        //social
        social.Should().HaveElement("reddit");
        social.Should().HaveElement("discord");
        social.Should().HaveElement("twitter");
        social.Should().HaveElement("website");
        social.Should().HaveElement("whitepaper");
        social.Should().HaveElement("verified");
        social.Should().HaveCount(6);
        
        //issuedcoins
        issuedcoin.Should().HaveElement("coin_name");
        issuedcoin.Should().HaveElement("confirmed_index");
        issuedcoin.Should().HaveElement("spent_index");
        issuedcoin.Should().HaveElement("coinbase");
        issuedcoin.Should().HaveElement("puzzle_hash");
        issuedcoin.Should().HaveElement("coin_parent");
        issuedcoin.Should().HaveElement("amount");
        issuedcoin.Should().HaveElement("timestamp");
        issuedcoin.Should().HaveElement("coin_info");
        issuedcoin.Should().HaveElement("extra_info");
        issuedcoin.Should().HaveElement("from_puzzle_hash");
        issuedcoin.Should().HaveElement("confirmed_time");
        issuedcoin.Should().HaveElement("spend_time");
        issuedcoin.Should().HaveElement("type");
        issuedcoin.Should().HaveCount(14);
    }
    
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getcatranks_matches_expected_schema()
    {
        // arrange

        // act
        var (_, httpResponse) = await Client.GetCATRanks();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var ranks = JArray.Parse(job.GetValue("data").ToString());
        var cat = ranks.First();

        // assert
        cat.Should().HaveElement("trades");
        cat.Should().HaveElement("amount");
        cat.Should().HaveElement("assets");
        cat.Should().HaveElement("xch_volume");
        cat.Should().HaveElement("usd_volume");
        cat.Should().HaveElement("coin_asset_id");
        cat.Should().HaveElement("asset_name");
        cat.Should().HaveElement("symbol");
        cat.Should().HaveElement("xch_price");
        cat.Should().HaveElement("usd_price");
        cat.Should().HaveElement("preview_url");
        cat.Should().HaveCount(11);
    }
    
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getcatholders_matches_expected_schema()
    {
        // arrange
        var assetId = "db1a9020d48d9d4ad22631b66ab4b9ebd3637ef7758ad38881348c5d24c38f20"; //Dexie bucks (DBX)

        // act
        var (_, httpResponse) = await Client.GetCATHolders(assetId);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var holders = JArray.Parse(job.GetValue("tokens").ToString());
        var holder = holders.First();

        // assert
        holder.Should().HaveElement("amount");
        holder.Should().HaveElement("address_hex");
        holder.Should().HaveElement("address");
        holder.Should().HaveCount(3);
    }
    
    [Fact]
    [Trait("Category", "Schema")]
    public async Task getcattransactions_matches_expected_schema()
    {
        // arrange
        var assetId = "db1a9020d48d9d4ad22631b66ab4b9ebd3637ef7758ad38881348c5d24c38f20"; //Dexie bucks (DBX)

        // act
        var (_, httpResponse) = await Client.GetCATTransactions(assetId);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        var holders = JArray.Parse(job.GetValue("data").ToString());
        var transaction = holders.First();
        var sender = transaction.Value<JObject>("sender");
        var receiver = transaction.Value<JObject>("receiver");
        
        // assert
        transaction.Should().HaveElement("coin_name");
        transaction.Should().HaveElement("coin_parent");
        transaction.Should().HaveElement("receiver");
        transaction.Should().HaveElement("amount");
        transaction.Should().HaveElement("type");
        transaction.Should().HaveElement("timestamp");
        transaction.Should().HaveElement("sender");
        transaction.Should().HaveElement("confirmed_time");
        transaction.Should().HaveElement("spend_time");
        transaction.Should().HaveCount(9);
        
        //sender
        sender.Should().HaveElement("address");
        sender.Should().HaveElement("address_hex");
        sender.Should().HaveCount(2);
        
        //receiver
        receiver.Should().HaveElement("address");
        receiver.Should().HaveElement("address_hex");
        receiver.Should().HaveCount(2);
    }
}