using Microsoft.EntityFrameworkCore;
using Poc_Kafika.API.Middleware;
using Poc_Kafka.Application;
using Poc_Kafka.Application.Services;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.ORM;
using Poc_Kafka.ORM.Repositories;

namespace Poc_Kafka.Domain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(DomainLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        services.AddHttpClient<ProducerService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7250");
        })
        .SetHandlerLifetime(TimeSpan.FromMinutes(3))
        .AddHttpMessageHandler<CircuitBreakerHandlerMiddleware>();

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
