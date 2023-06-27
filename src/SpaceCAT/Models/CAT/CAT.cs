namespace SpaceCAT.Models.CAT;

public class CAT
{
    public string id { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public int? holders { get; set; }
    public string issuance_type { get; set; }
    public IssuedCoin[] issued_coins { get; set; }
    public Int64 total_supply { get; set; }
    public int created_time { get; set; }
    public decimal price_usd { get; set; }
    public decimal price_xch { get; set; }
    public Social social { get; set; }
    public string tags { get; set; }
    public Int64 transactions { get; set; }
    public string preview_url { get; set; }
    public int multiplier { get; set; }
}

public class IssuedCoin
{
    public string coin_name { get; set; }
    public int confirmed_index { get; set; }
    public int spent_index { get; set; }
    public bool coinbase { get; set; }
    public string puzzle_hash { get; set; }
    public string coin_parent { get; set; }
    public Int64 amount { get; set; }
    public int timestamp { get; set; }
    public string coin_info { get; set; }
    public string extra_info { get; set; }
    public string from_puzzle_hash { get; set; }
    public DateTime confirmed_time { get; set; }
    public DateTime? spend_time { get; set; }
    public string type { get; set; }
}

public class Social
{
    public string reddit { get; set; }
    public string discord { get; set; }
    public string twitter { get; set; }
    public string website { get; set; }
    public string whitepaper { get; set; }
    public bool? verified { get; set; }
}