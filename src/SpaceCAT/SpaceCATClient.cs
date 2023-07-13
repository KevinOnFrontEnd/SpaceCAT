using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceCAT.Models;
using SpaceCAT.Models.Address;
using SpaceCAT.Models.CAT;
using SpaceCAT.Models.DID;
using SpaceCAT.Models.Stats;

namespace SpaceCAT;

public class SpaceCATClient : ISpaceCATClient
{
    private IOptions<SpaceScanOptions> _options { get; set; }
    private HttpClient _client { get; set; }
    private ILogger<SpaceCATClient> _logger { get; set; }
    
    public SpaceCATClient(IOptions<SpaceScanOptions> options, HttpClient httpClient, ILogger<SpaceCATClient> logger)
    {
        _options = options;
        _client = httpClient;
        _logger = logger;
    }
    
    #region CAT
    public async Task<(CAT,HttpResponseMessage)> GetCAT(string asset_id)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/cat/info/{asset_id}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetCATResponse>(responseBody);
        var cat = item?.data;
        return (cat, response);
    }
    
    public async Task<(CATRank[],HttpResponseMessage)> GetCATRanks(string timeperiod="1 Week", int page=1, int count=100)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/cat/ranks?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}&page={page}&count={count}&timeperiod={timeperiod}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetCATRanksResponse>(responseBody);
        var cat = item?.data;
        return (cat, response);
    }
    
    public async Task<(CATHolder[],HttpResponseMessage)> GetCATHolders(string asset_id)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/cat/holders/{asset_id}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetCATHoldersResponse>(responseBody);
        var holders = item?.tokens;
        return (holders, response);
    }
    
    public async Task<(CATTransaction[], HttpResponseMessage)> GetCATTransactions(string asset_id)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/cat/transactions/{asset_id}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetCATTransactionsResponse>(responseBody);
        var transactions = item?.data;
        return (transactions, response);
    }
    #endregion
    
    #region Address

    public async Task<(AddressBalance, HttpResponseMessage)> GetAddressBalance(string address,string type="xch")
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/address/balance/{address}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}&type={type}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<AddressBalanceResponse>(responseBody);
        var balances = item?.data;
        return (balances, response);
    }
    
    public async Task<(AddressIssuedCAT[], HttpResponseMessage)> GetAddressIssuedCATS(string address)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/address/issued-cats/{address}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<AddressIssuedCATSResponse>(responseBody);
        var cats = item?.cats;
        return (cats, response);
    }
    
    public async Task<(XCHTransactions, HttpResponseMessage)> GetAddressTransactions(string address)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/address/transactions/{address}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<AddressTransactionsResponse>(responseBody);
        var cats = item?.Data;
        return (cats, response);
    }

    public async Task<(AddressName[], HttpResponseMessage)> GetResolveAddressName(string name)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/address/resolve/{name}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<AddressNameResponse>(responseBody);
        var address = item?.Data;
        return (address, response);
    }
    #endregion

    #region Stats
    public async Task<(Price, HttpResponseMessage)> GetPrice(string curr="usd")
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/stats/price/{curr}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetPriceResponse>(responseBody);
        var price = item?.Data;
        return (price, response);
    }

    public async Task<(TotalSupply, HttpResponseMessage)> GetTotalSupply()
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/stats/total-supply?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetTotalSupplyResponse>(responseBody);
        var price = item?.Data;
        return (price, response);
    }

    public async Task<(DIDInfo, HttpResponseMessage)> GetDIDInfo(string did)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/did/info/{did}?authkey={_options.Value.AuthKey}&version=0.1.0&network={_options.Value.Network}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetDIDInfoResponse>(responseBody);
        var didInfo = item?.Data;
        return (didInfo, response);
    }

    #endregion
}