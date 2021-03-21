using GraphicscardAvailable.Implementation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GraphicscardAvailable_Functions.Startup))]

namespace GraphicscardAvailable_Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IIsAvailableHandler, Radion6900xIsAvailable>();

        }
    }
}
