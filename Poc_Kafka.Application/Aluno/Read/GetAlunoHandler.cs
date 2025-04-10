using System.Text.Json;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services.Interfaces;

namespace Poc_Kafka.Application.Aluno.Read
{
    public class GetAlunoHandler(IAlunoRepository alunoRepository, IProducerService producer)
        : ICommandHandler<GetAlunoCommand, GetAlunoResult>
    {
        private readonly IProducerService _producer = producer;
        private readonly IAlunoRepository _alunoRepository = alunoRepository;

        public async Task<GetAlunoResult> Handle(GetAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _alunoRepository.GetByIdAsync(command.Id, cancellationToken);

                var message = JsonSerializer.Serialize(response);

                await _producer.SendMessageAsync(message, cancellationToken);

                return GetAlunoResult.Create(response!.Id, response.Nome, response.Disciplina, response.Nota);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Obter Aluno. Message exception: {ex.Message}");
            }
        }
    }
}
