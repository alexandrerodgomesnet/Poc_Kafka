using System.Text;
using Poc_Kafka.Domain.Exceptions;
using Poc_Kafka.Domain.Services;

namespace Poc_Kafka.Application.Services;

public class ProducerService(HttpClient client) : IProducerService
{
    private readonly HttpClient _client = client;

    public async Task<string> SendMessageAsync(string message, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.SendAsync(new HttpRequestMessage
            {
                Content = new StringContent(message, Encoding.UTF8, "application/json"),
            });

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                return responseBody;
            }
        }
        catch (HttpResponseException ex)
        {
            throw new HttpResponseException("Erro ao enviar a mensagem", ex);
        }

        return string.Empty;
    }
}
