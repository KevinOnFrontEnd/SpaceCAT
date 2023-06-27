namespace SpaceCAT.Models.CAT;

public class GetCATHoldersResponse
{
    public string status { get; set; }
    public CATHolder[] tokens { get; set; }
}