using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpaceCAT.Models;

namespace SpaceCAT.Extensions;

public static class Extensions
{
    public static void AddSpaceCATClient(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var tibetSwapOptions = serviceProvider.GetRequiredService<IOptions<SpaceScanOptions>>()?.Value;
        if (tibetSwapOptions == null)
            throw new ArgumentException("SpaceCAT Configuration section missing!");
        if (string.IsNullOrEmpty(tibetSwapOptions?.ApiEndpoint))
            throw new ArgumentException("SpaceCAT.ApiEndpoint not defined");
        
        services.AddHttpClient<ISpaceCATClient, SpaceCATClient>(c =>
        {
            c.BaseAddress = new System.Uri(tibetSwapOptions.ApiEndpoint);
        });
    }
}