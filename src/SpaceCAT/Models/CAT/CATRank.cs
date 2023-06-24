namespace SpaceCAT.Models;

public class CATRank
{
    public int trades { get; set; }
    public Int64 amount { get; set; }
    public string assets { get; set; }
    public decimal xch_volume { get; set; }
    public decimal usd_volume { get; set; }
    public string coin_asset_id { get; set; }
    public string asset_name { get; set; }
    public string symbol { get; set; }
    public decimal xch_price { get; set; }
    public decimal usd_price { get; set; }
    public string preview_url { get; set; }
}