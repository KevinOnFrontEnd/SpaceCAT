using SpaceCAT.Models;

namespace SpaceCAT;

public interface ISpaceCATClient
{
    Task<CAT> GetCAT(string asset_id);
}