using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceCAT.Models;

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
    
    public async Task<(CAT,HttpResponseMessage)> GetCAT(string asset_id)
    {
        var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/{asset_id}");
        string responseBody = await response.Content.ReadAsStringAsync();
        _logger?.LogInformation(responseBody);
        var item = JsonConvert.DeserializeObject<GetCatResponse>(responseBody);
        var cat = item?.cat.FirstOrDefault();
        return (cat, response);
    }
}