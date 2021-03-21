using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using GraphicscardAvailable.Implementation;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphicscardAvailable.Functions
{
    public class ScanForAvailability
    {
        private readonly IIsAvailableHandler isAvailableHandler;

        public ScanForAvailability(IIsAvailableHandler isAvailableHandler)
        {
            this.isAvailableHandler = isAvailableHandler ?? throw new ArgumentNullException(nameof(isAvailableHandler));
        }

        [FunctionName("ScanForAvailability")]
        public async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            var result = await isAvailableHandler.Handle(new IsAvailableRequest());

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
