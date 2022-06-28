using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddSingleton<SampleService>();
// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
// Use the scheme/host/port used to fetch WSDL as that service endpoint address in generated WSDL 
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
#endregion

var app = builder.Build();

app.UseServiceModel(builder =>
{
    _ = builder.AddService<SampleService>()
        // Add a BasicHttpBinding at a specific endpoint
        .AddServiceEndpoint<SampleService, ISampleService>(new BasicHttpBinding(), "/SampleService/basichttp")
        // Add a WSHttpBinding with Transport Security for TLS
        .AddServiceEndpoint<SampleService, ISampleService>(new WSHttpBinding(SecurityMode.Transport), "/SampleService/WSHttps");
});

// Enable WSDL for http & https
var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
