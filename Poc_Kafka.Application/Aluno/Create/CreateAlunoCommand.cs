
using Poc_Kafka.Application.Abstractions.Messaging.Command;

namespace Poc_Kafka.Application.Aluno.Create;

public class CreateAlunoCommand : AlunoCommand, ICommand<CreateAlunoResult>
{
    private CreateAlunoCommand(string nome, string disciplina, decimal nota)
        : base(nome, disciplina, nota) { }

    public static CreateAlunoCommand Create(string nome, string disciplina, decimal nota) => new (nome, disciplina, nota);
}
