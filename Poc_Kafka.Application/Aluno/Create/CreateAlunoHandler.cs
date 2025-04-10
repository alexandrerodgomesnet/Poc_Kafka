using System.Text.Json;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Domain.Repositories;
using Poc_Kafka.Domain.Services.Interfaces;

namespace Poc_Kafka.Application.Aluno.Create
{
    public class CreateAlunoHandler(IAlunoRepository alunoRepository, IProducerService producer) 
        : ICommandHandler<CreateAlunoCommand, CreateAlunoResult>
    {
        private readonly IProducerService _producer = producer;
        private readonly IAlunoRepository _alunoRepository = alunoRepository;

        public async Task<CreateAlunoResult> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var aluno = Domain.Entities.Aluno.Create(command.Nome, command.Disciplina, command.Nota);

                var response = await _alunoRepository.CreateAsync(aluno, cancellationToken);

                var message = JsonSerializer.Serialize(response);

                await _producer.SendMessageAsync(message, cancellationToken);

                return CreateAlunoResult.Create(response.Id, response.Nome, response.Disciplina, response.Nota);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Aluno. Message exception: {ex.Message}");
            }
        }
    }
}
