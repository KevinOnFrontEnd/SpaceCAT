namespace SpaceCAT.Models.CAT;

public class GetCATRanksResponse
{
    public string Status { get; set; }
    public CATRank[] data { get; set; }
}