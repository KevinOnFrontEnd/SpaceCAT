namespace SpaceCAT.Models.Address;

public class AddressIssuedCAT
{
    public string id { get; set; }
    public string symbol { get; set; }
    public string  name {get;set;}
    public string description {get;set;}
    public string type {get;set;}
    public Int64? holders {get;set;}
    public string issuance_type { get; set; }
    public Int64? total_supply {get;set;}
    public string created_time {get;set;}
    public string price_usd {get;set;}
    public string price_xch {get;set;}
    public string tags {get;set;}
    public string multiplier {get;set;}
    public string transactions {get;set;}
    public string preview_url {get;set;}
}

public class AddressIssuedCATSocial
{
    public string reddit {get;set;}
    public string discord{get;set;}
    public string twitter{get;set;}
    public string website{get;set;}
    public string whitepaper{get;set;}
    public string verified{get;set;}
}