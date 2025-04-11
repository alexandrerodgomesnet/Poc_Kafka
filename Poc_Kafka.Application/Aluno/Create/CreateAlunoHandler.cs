using System.Text.Json;
using Microsoft.Extensions.Logging;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services;

namespace Poc_Kafka.Application.Aluno.Create
{
    public class CreateAlunoHandler(IAlunoRepository alunoRepository, IProducerService service,
        ILogger<CreateAlunoHandler> logger) : ICommandHandler<CreateAlunoCommand, CreateAlunoResult>
    {
        private readonly IAlunoRepository _alunoRepository = alunoRepository;
        private readonly IProducerService _service = service;
        private readonly ILogger<CreateAlunoHandler> _logger = logger;

        public async Task<CreateAlunoResult> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var aluno = Domain.Entities.Aluno.Create(command.Nome, command.Disciplina, command.Nota);

                var response = await _alunoRepository.CreateAsync(aluno, cancellationToken);

                var message = JsonSerializer.Serialize(response);

                var resultMessage = await _service.SendMessageAsync(message, cancellationToken);

                _logger.LogInformation($"Aluno criado: {resultMessage}");

                return CreateAlunoResult.Create(response.Id, response.Nome, response.Disciplina, response.Nota);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Aluno. Message exception: {ex.Message}");
            }
        }
    }
}
