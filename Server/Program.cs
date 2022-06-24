using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

#region Services
builder.Services.AddSingleton<SampleService>();
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
#endregion

var app = builder.Build();

app.UseServiceModel(builder =>
{
    builder.AddService<SampleService>()
    // Add a BasicHttpBinding at a specific endpoint
    .AddServiceEndpoint<SampleService, ISampleService>(new BasicHttpBinding(), "/SampleService/basichttp")
     // Add a WSHttpBinding with Transport Security for TLS
    .AddServiceEndpoint<SampleService, ISampleService>(new WSHttpBinding(SecurityMode.Transport), "/SampleService/WSHttps");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
