namespace Poc_Kafka.Producer.API.Services.Interfaces;

public interface IProducerService
{
    Task<string> SendMessageAsync(string message, CancellationToken cancellationToken);
}
