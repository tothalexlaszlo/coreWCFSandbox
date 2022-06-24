using CoreWCF;
using Server.Models;

namespace Server.Services
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        WSMPRequestResponseRP GetResourcePropertyDocument();
    }
}
