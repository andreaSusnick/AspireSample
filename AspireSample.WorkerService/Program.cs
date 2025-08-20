using AspireSample.WorkerService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddAzureServiceBusClient("serviceBusConnection");

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();