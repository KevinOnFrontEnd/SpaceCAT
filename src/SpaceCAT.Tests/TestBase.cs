using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaceCAT.Extensions;
using SpaceCAT.Models;
using Xunit;

namespace SpaceCAT.Tests;

[Collection("Integration")]
public class TestBase : IClassFixture<SpaceCATTestFixture>
{
    public SpaceCATTestFixture Fixture { get; }
    public ISpaceCATClient Client =>  TestHost.Services.GetService<ISpaceCATClient>();
    public IHost TestHost { get; }
    
    public TestBase(SpaceCATTestFixture fixture)
    {
        Fixture = fixture;
        TestHost = CreateHostBuilder().Build();
        Task.Run(() =>
        { 
            return TestHost.StartAsync();
        });
    }
    
    public IHostBuilder? CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(b =>
        {
            b.ConfigureAppConfiguration((hostContext, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configurationBuilder.AddJsonFile("testingappsettings.json", optional: false);
                configurationBuilder.AddEnvironmentVariables();
                configurationBuilder.AddUserSecrets(nameof(SpaceScanOptions));
            });


        }).ConfigureWebHost(host =>
        {
             host.ConfigureServices((hostContext, services) =>
            {
                services.Configure<SpaceScanOptions>(hostContext.Configuration.GetSection("SpaceCAT"));
                services.AddSpaceCATClient();
            });
        });
    }
    
    public void Dispose()
    {
        Task.Run(() => TestHost.StopAsync());
    }
}