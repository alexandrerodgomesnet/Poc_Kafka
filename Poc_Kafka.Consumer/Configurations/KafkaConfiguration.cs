namespace Poc_Kafka.Consumer.Configurations;

public class KafkaConfiguration
{
    public string Server { get; set; } = "localhost:9092";
    public string TopicName { get; set; } = "topic-aluno";
    public string GroupId { get; set; } = "group-aluno";
}