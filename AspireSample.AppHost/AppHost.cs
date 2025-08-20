var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var db = builder.AddPostgres("db");

// Add Azure Service Bus connection (without creating topics/subscriptions)
var serviceBus = builder.AddAzureServiceBus("serviceBusConnection");

var api = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(serviceBus);

builder.AddProject<Projects.AspireSample_Web>("web")
       .WithReference(api);

builder.AddProject<Projects.AspireSample_WorkerService>("aspiresample-workerservice")
    .WithReference(serviceBus);

builder.Build().Run();
