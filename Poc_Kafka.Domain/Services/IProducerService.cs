namespace Poc_Kafka.Domain.Services;

public interface IProducerService
{
    Task<string> SendMessageAsync(string message, CancellationToken cancellationToken);
}
