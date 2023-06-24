namespace SpaceCAT.Models.CAT;

public class GetCATTransactionsResponse
{
    public string Status { get; set; }
    public CATTransaction[] data { get; set; }
}