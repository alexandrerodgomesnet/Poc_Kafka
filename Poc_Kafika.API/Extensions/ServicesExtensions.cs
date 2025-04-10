using Microsoft.EntityFrameworkCore;
using Poc_Kafka.Application;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services;
using Poc_Kafka.Domain.Services.Interfaces;
using Poc_Kafka.ORM;
using Poc_Kafka.ORM.Repositories;
using Poc_Kafka.Producer;

namespace Poc_Kafka.Domain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProducerService, ProducerService>();

        services
            .AddScoped<KafkaConfiguration>()
            .Configure<KafkaConfiguration>(a => configuration.GetSection(nameof(KafkaConfiguration))
            .Bind(a));

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(DomainLayer).Assembly,
                typeof(Program).Assembly
            );
        });        

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Poc_Kafka.ORM")
            )
        );

        services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        services.AddScoped<IAlunoRepository, AlunoRepository>();

        return services;
    }
}
