using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using GraphicscardAvailable.Implementation;

namespace GraphicscardAvailable.Functions
{
    public static class ScanForAvailability
    {
        [FunctionName("ScanForAvailability")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
         
             


            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}, {new Class1().SaySomething}");
        }
    }
}
