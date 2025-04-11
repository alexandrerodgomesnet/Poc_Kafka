using Microsoft.AspNetCore.Mvc;
using Poc_Kafka.Producer.API.Services.Interfaces;

namespace Poc_Kafka.Producer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController(IProducerService producer) : ControllerBase
    {
        private readonly IProducerService _producer = producer;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string message, CancellationToken cancellationToken)
        {
            var result = await _producer.SendMessageAsync(message, cancellationToken);

            return Created(string.Empty, result);
        }
    }
}
