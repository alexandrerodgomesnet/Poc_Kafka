using Poc_Kafka.Application;
using Poc_Kafka.Domain.Services;
using Poc_Kafka.Domain.Services.Interfaces;
using Poc_Kafka.Producer;

namespace Poc_Kafka.Domain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        })
        .AddScoped<IProducerService, ProducerService>()
        .Configure<KafkaConfiguration>(a => configuration.GetSection(nameof(KafkaConfiguration))
        .Bind(a));

        return services;
    }
}
