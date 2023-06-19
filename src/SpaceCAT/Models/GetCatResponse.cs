namespace SpaceCAT.Models;

public class GetCatResponse
{
    public string Status { get; set; }
    public CAT[] cat { get; set; }
}