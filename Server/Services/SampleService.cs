using CoreWCF;
using Server.Models;

namespace Server.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SampleService : ISampleService
    {
        private readonly ILogger<SampleService> _logger;

        public SampleService(ILogger<SampleService> logger)
        {
            _logger = logger;
        }

        public WSMPRequestResponseRP GetResourcePropertyDocument()
        {
            Console.WriteLine("GetResourcePropertyDocument Executed!");
            _logger.LogInformation("GetResourcePropertyDocument Executed!");
            return new();
        }
    }
}
