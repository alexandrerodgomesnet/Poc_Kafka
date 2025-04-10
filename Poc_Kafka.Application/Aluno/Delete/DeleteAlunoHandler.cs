using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services.Interfaces;

namespace Poc_Kafka.Application.Aluno.Delete;

public class DeleteAlunoHandler(IProducerService producer, IAlunoRepository alunoRepository) 
    : ICommandHandler<DeleteAlunoCommand, DeleteAlunoResult>
{
    private readonly IProducerService _producer = producer;
    private readonly IAlunoRepository _alunoRepository = alunoRepository;

    public async Task<DeleteAlunoResult> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _alunoRepository.DeleteAsync(command.Id, cancellationToken);
            if(response)
            {
                var message = $"Aluno com Id: {command.Id} excluido com sucesso!";

                await _producer.SendMessageAsync(message, cancellationToken);
            }

            return DeleteAlunoResult.Create(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao Excluir Aluno. Message exception: {ex.Message}");
        }
    }
}
