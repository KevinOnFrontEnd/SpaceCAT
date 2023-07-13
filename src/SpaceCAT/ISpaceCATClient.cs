using SpaceCAT.Models;
using SpaceCAT.Models.Address;
using SpaceCAT.Models.CAT;
using SpaceCAT.Models.DID;
using SpaceCAT.Models.Stats;

namespace SpaceCAT;

public interface ISpaceCATClient
{
    #region CAT

    Task<(CAT, HttpResponseMessage)> GetCAT(string asset_id);
    Task<(CATRank[], HttpResponseMessage)> GetCATRanks(string timeperiod = "1 Week", int page = 1, int count = 100);
    Task<(CATHolder[], HttpResponseMessage)> GetCATHolders(string asset_id);
    Task<(CATTransaction[], HttpResponseMessage)> GetCATTransactions(string asset_id);

    #endregion

    #region Address
    Task<(AddressBalance, HttpResponseMessage)> GetAddressBalance(string address, string type="xch");
    Task<(AddressIssuedCAT[], HttpResponseMessage)> GetAddressIssuedCATS(string address);
    Task<(XCHTransactions, HttpResponseMessage)> GetAddressTransactions(string address);
    Task<(AddressName[], HttpResponseMessage)> GetResolveAddressName(string name);
    #endregion
    
    #region Stats
    Task<(Price, HttpResponseMessage)> GetPrice(string curr="usd");
    Task<(TotalSupply, HttpResponseMessage)> GetTotalSupply();
    #endregion
    
    #region DID

    Task<(DIDInfo, HttpResponseMessage)> GetDIDInfo(string did);

    #endregion
}