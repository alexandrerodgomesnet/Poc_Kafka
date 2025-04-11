using Poc_Kafka.Domain.Exceptions;
using Polly.CircuitBreaker;
using Polly;

namespace Poc_Kafika.API.Middleware
{
    public class CircuitBreakerHandlerMiddleware : DelegatingHandler
    {
        public readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _retryPolicy =
            Policy.HandleResult<HttpResponseMessage>(r => (int)r.StatusCode >= 500 || !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(1));

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var policyResult = await _retryPolicy.ExecuteAndCaptureAsync(() =>
                base.SendAsync(request, cancellationToken));

            if (policyResult.Outcome == OutcomeType.Failure)
                throw new HttpResponseException("Erro ao executar o envio do request", policyResult.FinalException);

            return policyResult.Result;
        }
    }
}
