using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using GraphicscardAvailable.Implementation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;

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
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            var isAvailableResult = await isAvailableHandler.Handle(new IsAvailableRequest());

            return new OkObjectResult(isAvailableResult);
        }
    }
}
