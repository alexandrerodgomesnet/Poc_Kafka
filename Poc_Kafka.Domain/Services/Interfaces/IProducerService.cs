namespace Poc_Kafka.Domain.Services.Interfaces;

public interface IProducerService
{
    Task<string> SendMessageAsync(string message, CancellationToken cancellationToken);
}
