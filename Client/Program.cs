using ServiceReference;

using var client = new SampleServiceClient(SampleServiceClient.EndpointConfiguration.BasicHttpBinding_ISampleService, "http://localhost:5000/SampleService/basichttp");
var result = await client.GetResourcePropertyDocumentAsync();

Console.WriteLine($"Result: {result}");
