using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Poc_Kafka.Domain.Services;
using Poc_Kafka.Domain.Services.Interfaces;

namespace Poc_Kafka.Producer;

public class ProducerService : IProducerService
{
    private readonly ProducerConfig _producerConfig;
    private readonly KafkaConfiguration _kafkaConfiguration;
    private readonly ILogger<ProducerService> _logger;

    public ProducerService(ILogger<ProducerService> logger, KafkaConfiguration kafkaConfiguration)
    {
        _kafkaConfiguration = kafkaConfiguration;
        _logger = logger;

        _producerConfig = new ProducerConfig()
        {
            BootstrapServers = _kafkaConfiguration.Server
        };
        
    }

    public async Task<string> SendMessageAsync(string message, CancellationToken cancellationToken)
    {
        try
        {
            using var producer = new ProducerBuilder<Null, string>(_producerConfig).Build();
            var result = await producer.ProduceAsync(_kafkaConfiguration.TopicName, new() { Value = message }, cancellationToken);
            var retString = $"{result.Status.ToString()} - {message}";
            _logger.LogInformation(retString);
            return retString;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return string.Empty;
    }
}
