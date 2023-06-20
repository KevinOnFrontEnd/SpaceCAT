namespace SpaceCAT.Models;

public class CAT
{
    public string asset_id { get; set; }
    public string asset_name { get; set; }
    public string symbol { get; set; }
    public decimal price_usd { get; set; }
    public decimal price_xch { get; set; }
    public int issued_time { get; set; }
    public int updated { get; set; }
    public int holders { get; set; }
    public string lisp { get; set; }
    public string clvm { get; set; }
    public string description { get; set; }
    public string tags { get; set; }
    public string total_supply { get; set; }
    public string txns_count { get; set; }
    public string txns_amount { get; set; }
    public string logo { get; set; }
    public string discord { get; set; }
    public string website { get; set; }
    public string whitepaper { get; set; }
    public string reddit { get; set; }
    public string cat_type { get; set; }
    public string cat_description { get; set; }
    public string details { get; set; }
}