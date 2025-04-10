using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poc_Kafka.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(service =>
    {
        service.AddHostedService<ConsumerService>();
    })
    .Build();

await host.RunAsync();
