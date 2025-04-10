using Poc_Kafka.Application.Abstractions.Messaging.Command;

namespace Poc_Kafka.Application.Aluno.Read;

public class GetAlunoCommand : ICommand<GetAlunoResult>
{
    public Guid Id { get; }

    private GetAlunoCommand(Guid id)
    {
        Id = id;
    }

    public static GetAlunoCommand Create(Guid id) => new(id);
}
