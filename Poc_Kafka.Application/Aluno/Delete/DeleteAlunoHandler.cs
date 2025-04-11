using Microsoft.Extensions.Logging;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Application.Aluno.Create;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services;

namespace Poc_Kafka.Application.Aluno.Delete;

public class DeleteAlunoHandler(IAlunoRepository alunoRepository, IProducerService service,
    ILogger<DeleteAlunoHandler> logger) : ICommandHandler<DeleteAlunoCommand, DeleteAlunoResult>
{
    private readonly IAlunoRepository _alunoRepository = alunoRepository;
    private readonly IProducerService _service = service;
    private readonly ILogger<DeleteAlunoHandler> _logger = logger;

    public async Task<DeleteAlunoResult> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _alunoRepository.DeleteAsync(command.Id, cancellationToken);
            if(response)
            {
                var message = $"Aluno com Id: {command.Id} excluido com sucesso!";

                var resultMessage = await _service.SendMessageAsync(message, cancellationToken);

                _logger.LogInformation($"Aluno deletado: {resultMessage}");
            }

            return DeleteAlunoResult.Create(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao Excluir Aluno. Message exception: {ex.Message}");
        }
    }
}
