using System.Text.Json;
using Microsoft.Extensions.Logging;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Application.Aluno.Delete;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services;

namespace Poc_Kafka.Application.Aluno.Update;

public class UpdateAlunoHandler(IAlunoRepository alunoRepository, IProducerService service,
    ILogger<UpdateAlunoHandler> logger) : ICommandHandler<UpdateAlunoCommand, UpdateAlunoResult>
{
    private readonly IAlunoRepository _alunoRepository = alunoRepository;
    private readonly IProducerService _service = service;
    private readonly ILogger<UpdateAlunoHandler> _logger = logger;
    public async Task<UpdateAlunoResult> Handle(UpdateAlunoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var aluno = Domain.Entities.Aluno.Create(command.Nome, command.Disciplina, command.Nota);

            var response = await _alunoRepository.UpdateAsync(aluno, cancellationToken);

            var message = JsonSerializer.Serialize(response);

            var resultMessage = await _service.SendMessageAsync(message, cancellationToken);

            _logger.LogInformation($"Aluno Atualizado: {resultMessage}");

            return UpdateAlunoResult.Create(response.Id, response.Nome, response.Disciplina, response.Nota);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao Atualizar o Aluno. Message exception: {ex.Message}");
        }
    }
}
