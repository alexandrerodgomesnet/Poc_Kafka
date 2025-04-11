using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poc_Kafka.Consumer;
using Poc_Kafka.Consumer.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, service) => 
    {
        service.AddHostedService<ConsumerService>();
           //.AddScoped<KafkaConfiguration>()
           //.Configure<KafkaConfiguration>(k => builder.Configuration.GetSection(nameof(KafkaConfiguration))
           //.Bind(k));
    })
    .Build();

await host.RunAsync();
