using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceCAT.Models;

namespace SpaceCAT;

public class SpaceCATClient : ISpaceCATClient
{
    private IOptions<SpaceScanOptions> _options { get; set; }
    private HttpClient _client { get; set; }
    
    public SpaceCATClient(IOptions<SpaceScanOptions> options, HttpClient httpClient)
    {
        _options = options;
        _client = httpClient;
    }
    public async Task<(CAT,HttpResponseMessage)> GetCAT(string asset_id)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/{asset_id}");
        string responseBody = await response.Content.ReadAsStringAsync();
        var item = JsonConvert.DeserializeObject<GetCatResponse>(responseBody);
        var cat = item?.cat.FirstOrDefault();
        return (cat, response);
    }
}