using Poc_Kafka.Application.Abstractions.Messaging.Command;

namespace Poc_Kafka.Application.Aluno.Update;

public class UpdateAlunoCommand : AlunoCommand, ICommand<UpdateAlunoResult>
{
    public UpdateAlunoCommand(Guid id, string nome, string disciplina, decimal nota) 
        : base(nome, disciplina, nota)
    {
        Id = id;
    }
    public Guid Id { get; set; }

    public static UpdateAlunoCommand Create(Guid id, string nome, string disciplina, decimal nota) => 
        new(id, nome, disciplina, nota);
}
