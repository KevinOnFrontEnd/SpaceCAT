# SpaceCAT
Simple HttpClient for interacting with spacescan.io CAT API to fetch CAT Details.


# Setup
```C#
{
    services.Configure<SpaceScanOptions>(hostContext.Configuration.GetSection("SpaceCAT"));
    services.AddSpaceCATClient();
}
```

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
var (cat, httpResponse) = client.GetCAT("YOUR ASSET ID")
```

# Build Status
![Build](https://github.com/kevinonfrontend/SpaceCAT/actions/workflows/build_and_test.yml/badge.svg)
