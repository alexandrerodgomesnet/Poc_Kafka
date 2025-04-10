
namespace Poc_Kafka.Application.Aluno.Delete;

public class DeleteAlunoResult
{
    public bool Success { get; set; }
    public DeleteAlunoResult(bool success)
    {
        Success = success;
    }

    public static DeleteAlunoResult Create(bool response) => new(response);
}
