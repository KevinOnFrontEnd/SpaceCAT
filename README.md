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
    "ApiEndPoint": "https://api2.spacescan.io/v0.1/xch/cat"
  }
```

# Usage
Inject ISpaceCATClient into required class.

```C#
var (cat, httpResponse) = client.GetCAT("YOUR ASSET ID")
```
