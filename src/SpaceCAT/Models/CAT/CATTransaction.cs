namespace SpaceCAT.Models.CAT;

public class CATTransaction
{
    public string coin_name { get; set; }
    public string coin_parent { get; set; }
    public CATTransactionReceiver CATTransactionReceiver { get; set; }
    public CATTransactionSender sender { get; set; }
    public decimal amount { get; set; }
    public string type { get; set; }
    public int timestamp { get; set; }
    public DateTime? confirmed_time { set; get; }
    public DateTime? spend_time { get; set; }
}

public class CATTransactionReceiver
{
    public string address { get; set; }
    public string address_hex { get; set; }
}

public class CATTransactionSender
{
    public string address { get; set; }
    public string address_hex { get; set; }
}