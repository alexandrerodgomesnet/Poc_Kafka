using Poc_Kafka.Application.Abstractions.Messaging.Command;

namespace Poc_Kafka.Application.Aluno.Delete;

public class DeleteAlunoCommand : ICommand<DeleteAlunoResult>
{
    public Guid Id { get; }

    private DeleteAlunoCommand(Guid id)
    {
        Id = id;
    }

    public static DeleteAlunoCommand Create(Guid id) => new(id);
}
