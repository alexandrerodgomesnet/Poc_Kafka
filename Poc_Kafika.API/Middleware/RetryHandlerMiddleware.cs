using Poc_Kafka.Domain.Exceptions;
using Polly;
using Polly.Retry;

namespace Poc_Kafika.API.Middleware;

public class RetryHandlerMiddleware : DelegatingHandler
{
    public readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy =
        Policy.HandleResult<HttpResponseMessage>(r =>
            r.StatusCode == System.Net.HttpStatusCode.TooManyRequests || (int)r.StatusCode >= 500 || !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            );

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken )
    {
        var policyResult = await _retryPolicy.ExecuteAndCaptureAsync(() =>
            base.SendAsync(request, cancellationToken));

        if (policyResult.Outcome == OutcomeType.Failure)
            throw new HttpResponseException("Erro ao executar o envio do request", policyResult.FinalException);

        return policyResult.Result;
    }
}
