using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpaceCAT.Models;

namespace SpaceCAT.Extensions;

public static class Extensions
{
    public static void AddSpaceCATClient(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var spaceScanOptions = serviceProvider.GetRequiredService<IOptions<SpaceScanOptions>>()?.Value;
        if (spaceScanOptions == null)
            throw new ArgumentException("SpaceCAT Configuration section missing!");
        if (string.IsNullOrEmpty(spaceScanOptions?.ApiEndpoint))
            throw new ArgumentException("SpaceCAT.ApiEndpoint not defined");
        
        services.AddHttpClient<ISpaceCATClient, SpaceCATClient>(c =>
        {
            c.BaseAddress = new System.Uri(spaceScanOptions.ApiEndpoint);
        });
    }
}