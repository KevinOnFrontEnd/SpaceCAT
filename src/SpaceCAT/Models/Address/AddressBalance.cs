using System.Dynamic;

namespace SpaceCAT.Models.Address;

public class AddressBalance
{
    public Balance Balance { get; set; }
    public Received Received { get; set; }
    public Sent Sent { get; set; }
}

public class Balance
{
    public decimal mojo { get; set; }
    public decimal xch { get; set; }
    public decimal usd { get; set; }
}

public class Received
{
    public decimal mojo { get; set; }
    public decimal xch { get; set; }
    public decimal usd { get; set; }
}

public class Sent
{
    public decimal mojo { get; set; }
    public decimal xch { get; set; }
    public decimal usd { get; set; }
}