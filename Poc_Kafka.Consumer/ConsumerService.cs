using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Poc_Kafka.Consumer.Configurations;

namespace Poc_Kafka.Consumer
{
    public class ConsumerService : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<ConsumerService> _logger;
        private readonly KafkaConfiguration _configuration;

        public ConsumerService(ILogger<ConsumerService> logger)
        //public ConsumerService(ILogger<ConsumerService> logger, KafkaConfiguration configuration)
        {            
            _logger = logger;
            _configuration = new KafkaConfiguration();

            _consumer = new ConsumerBuilder<Ignore, string>(new ConsumerConfig
            {
                BootstrapServers = _configuration.Server,
                GroupId = _configuration.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            })
            .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Waiting for messages");
            _consumer.Subscribe(_configuration.TopicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.FromResult(() =>
                {
                    var result = _consumer.Consume(stoppingToken);
                    //var m = JsonSerializer.Deserialize<object>(result.Message.Value); exemplo para usar quando for json  em classe
                    _logger.LogInformation($"GroupId: {_configuration.GroupId} - Message: {result.Message.Value}");
                });
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Close();
            _logger.LogInformation("Conecction closed.");
            return Task.CompletedTask;
        }
    }
}
