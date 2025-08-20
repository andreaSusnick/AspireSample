using Azure.Messaging.ServiceBus;

// Connection string should be passed as an environment variable or command line argument
// For testing: set SERVICEBUS_CONNECTION_STRING environment variable
var connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING") 
    ?? throw new InvalidOperationException("SERVICEBUS_CONNECTION_STRING environment variable is required");

Console.WriteLine("Testing Service Bus connection...");

try 
{
    Console.WriteLine("Creating ServiceBusClient...");
    var client = new ServiceBusClient(connectionString);
    
    Console.WriteLine("Testing connection by creating sender...");
    var sender = client.CreateSender("notifications");
    
    Console.WriteLine("✅ Service Bus connection successful!");
    
    await sender.DisposeAsync();
    await client.DisposeAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Service Bus connection failed: {ex.Message}");
    Console.WriteLine($"Exception type: {ex.GetType().Name}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
    }
}

Console.WriteLine("Test completed. Press any key to exit...");
Console.ReadKey();
