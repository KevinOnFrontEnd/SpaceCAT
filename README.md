# SpaceCAT
Simple HttpClient for interacting with spacescan.io CAT API to fetch CAT Details.


# Setup
```C#
{
    services.Configure<SpaceScanOptions>(hostContext.Configuration.GetSection("SpaceCAT"));
    services.AddSpaceCATClient();
}
```

## Mainnet
Add configuration to appsettings.json
```JSON
  "SpaceCAT": {
    "ApiEndPoint": "https://api.spacescan.io",
    "AuthKey": "YOUR auth key acquired from spacescan  (https://test.spacescan.io/manage-userinfo)",
    "Network" : "mainnet"
}
```

# Usage
Inject ISpaceCATClient into required class.

```C#
//cat
var (cat, httpResponse) = client.GetCAT("YOUR ASSET ID")
var (ranks, httpResponse) = await Client.GetCATRanks();
var (holders, httpResponse) = await Client.GetCATHolders(assetId);
var (transactions, httpResponse) = await Client.GetCATTransactions(assetId); 

//address
var (balances, httpResponse) = await Client.GetAddressBalance(address);
var (issuedcats, httpResponse) = await Client.GetAddressIssuedCATS(address);
 var (names, httpResponse) = await Client.GetResolveAddressName(name);

//stats
var (price, httpResponse) = await Client.GetPrice();
var (totalsupply, httpResponse) = await Client.GetTotalSupply();

//did - 1 of 6 implemented
var (did, httpResponse) = await Client.GetDIDInfo(did);


//OFFERS
WIP

//BLOCK
WIP

//NFT
WIP

//MEMPOOL
WIP

```

# Build Status
![Build](https://github.com/kevinonfrontend/SpaceCAT/actions/workflows/build_and_test.yml/badge.svg)
