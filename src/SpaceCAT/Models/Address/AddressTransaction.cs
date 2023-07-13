namespace SpaceCAT.Models.Address;

public class AddressTransaction
{
    public XCHTransactions xch { get; set; }
    // public string nft { get; set; }
    // public string cat { get; set; }
}

public class XCHTransactions
{
    public InTransaction[] In { get; set; }
    public OutTransaction[] Out { get; set; }
}

public class InTransaction
{
    public string Coin_Name { get; set; }
    public int? Confirmed { get; set; }
    public DateTime? Confirmed_Time { get; set; }
    public int? Spent { get; set; }
    public DateTime? Spent_Time { get; set; }
    public bool? Farmer_Reward { get; set; }
    public string Parent { get; set; }
    public decimal? Amount { get; set; }
    public Int64? Mojo { get; set; }
    public string Type { get; set; }
}

public class OutTransaction
{
    public string Coin_Name { get; set; }
    public int? Confirmed { get; set; }
    public DateTime? Confirmed_Time { get; set; }
    public int? Spent { get; set; }
    public DateTime? Spent_Time { get; set; }
    public bool? Farmer_Reward { get; set; }
    public string Parent { get; set; }
    public decimal? Amount { get; set; }
    public Int64? Mojo { get; set; }
    public string Type { get; set; }
}

public class TransactionAddress
{
    public string Address { get; set; }
    public string Address_Hex { get; set; }
}

