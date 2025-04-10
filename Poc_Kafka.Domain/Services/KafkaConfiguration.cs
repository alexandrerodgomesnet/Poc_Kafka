namespace Poc_Kafka.Domain.Services;

public class KafkaConfiguration
{
    public string Server { get; set; } = string.Empty;
    public string TopicName { get; set; } = string.Empty;
    public string GroupId { get; set; } = string.Empty;
}
