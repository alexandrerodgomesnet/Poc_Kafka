using System.Text.Json;
using Poc_Kafka.Application.Abstractions.Messaging.Command;
using Poc_Kafka.Domain.Repositories;

namespace Poc_Kafka.Application.Aluno.Read
{
    public class GetAlunoHandler(IAlunoRepository alunoRepository) : ICommandHandler<GetAlunoCommand, GetAlunoResult>
    {
        private readonly IAlunoRepository _alunoRepository = alunoRepository;

        public async Task<GetAlunoResult> Handle(GetAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _alunoRepository.GetByIdAsync(command.Id, cancellationToken);

                var message = JsonSerializer.Serialize(response);

                return GetAlunoResult.Create(response!.Id, response.Nome, response.Disciplina, response.Nota);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Obter Aluno. Message exception: {ex.Message}");
            }
        }
    }
}
