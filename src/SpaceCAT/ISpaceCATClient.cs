using SpaceCAT.Models;

namespace SpaceCAT;

public interface ISpaceCATClient
{
    Task<(CAT,HttpResponseMessage)> GetCAT(string asset_id);
}