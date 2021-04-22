using GraphicscardAvailable.Implementation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;

[assembly: FunctionsStartup(typeof(GraphicscardAvailable_Functions.Startup))]

namespace GraphicscardAvailable_Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddHttpClient(Options.DefaultName)
                .ConfigurePrimaryHttpMessageHandler(() => 
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    });

            builder.Services.AddSingleton<IIsAvailableHandler, Radion6900xIsAvailable>();
        }
    }
}
